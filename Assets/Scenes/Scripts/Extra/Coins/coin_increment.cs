using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

public class coin_increment : MonoBehaviour
{
    public Text score_txt; // Texto da UI para o score atual.
    public Text Ui_end_score; // Texto da UI para o score final.
    public string DataBaseName; // Nome do banco de dados.
    private CoinTracker coins; // Referência para o rastreador de moedas.
    private bool updateCompleted = false; // Flag para verificar se a atualização do banco de dados foi concluída.

    public void Start(){
        coins = FindObjectOfType<CoinTracker>();
    }

    public void adicionaMoedas(bool condition)
    {
        if (condition && !updateCompleted)
        {
            int score_total = coins.score;
            int currentScore = int.Parse(score_txt.text);
            if(currentScore < score_total)
            {
                // Incrementa o score na UI até que alcance score_total.
                currentScore += 1;
                score_txt.text = currentScore.ToString();
                Ui_end_score.text = "+" + currentScore.ToString();
            }
            else if (currentScore >= score_total && !updateCompleted)
            {
                // Atualiza o banco de dados uma vez quando o score na UI alcança score_total.
                Ui_end_score.text = "+" + score_total.ToString();
                updateCompleted = true; // Define a flag para evitar múltiplas atualizações.


                string conn = SetDataBaseClass.SetDataBase(DataBaseName + ".db");
                using (IDbConnection dbcon = new SqliteConnection(conn))
                {
                    dbcon.Open();
                    using (IDbCommand dbcmd = dbcon.CreateCommand())
                    {
                        int ID = PlayerPrefs.GetInt("ID", -1);
                        int moedasParaAdicionar = score_total;

                        string sqlQuery = "UPDATE Users SET moedas = moedas + @moedasParaAdicionar WHERE ID = @ID";
                        dbcmd.CommandText = sqlQuery;
                        Debug.Log(Ui_end_score);
                        Debug.Log(score_total);
                        Debug.Log(moedasParaAdicionar);
                        Debug.Log(coins.score);

                        dbcmd.Parameters.Add(new SqliteParameter("@moedasParaAdicionar", moedasParaAdicionar));
                        dbcmd.Parameters.Add(new SqliteParameter("@ID", ID));

                        dbcmd.ExecuteNonQuery();
                    }
                    dbcon.Close();
                }
            }
        }
    }
}
