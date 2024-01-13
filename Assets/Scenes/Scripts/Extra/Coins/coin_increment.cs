using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

public class coin_increment : MonoBehaviour
{
    private int score;
    private int score_ui;
    public Text score_txt;
    public Text Ui_end_score;
    public string DataBaseName;

    public void adicionaMoedas(bool condition)
    {
        if (condition == true)
        {
            int score_total = CoinTracker.score;
            if(score_ui < score_total)
            {
                // Incrementa score_ui até que alcance score_total
                score_ui += 1;
                Ui_end_score.text = "+" + score_ui.ToString();
            }
            else if (score_ui == score_total)
            {
                // Quando score_ui alcança score_total, atualiza o banco de dados uma vez
                score = score_total;

                // Atualiza a coluna moedas
                string conn = SetDataBaseClass.SetDataBase(DataBaseName + ".db");
                using (IDbConnection dbcon = new SqliteConnection(conn))
                {
                    dbcon.Open();
                    using (IDbCommand dbcmd = dbcon.CreateCommand())
                    {
                        int ID = PlayerPrefs.GetInt("ID", -1);
                        int moedasParaAdicionar = score_total; // Valor fixo para adicionar

                        // Preparar o comando SQL para incrementar a coluna moedas
                        string sqlQuery = "UPDATE Users SET moedas = moedas + @moedasParaAdicionar WHERE ID = @ID";
                        dbcmd.CommandText = sqlQuery;

                        // Adicionar os parâmetros ao comando
                        dbcmd.Parameters.Add(new SqliteParameter("@moedasParaAdicionar", moedasParaAdicionar));
                        dbcmd.Parameters.Add(new SqliteParameter("@ID", ID));

                        // Executar o comando
                        dbcmd.ExecuteNonQuery();
                    }
                    dbcon.Close();
                }

                // Evita múltiplas atualizações após alcançar o score_total
                score_ui++;
            }

            // Atualiza o texto da UI com o novo score
            score_txt.text = score.ToString();
        }
    }
}