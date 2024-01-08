using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

public class Minigame_select : MonoBehaviour
{

    public Text textName;
    public Text IntMoedas; // Alterado de Integer para Text
    public string DataBaseName;

    void Start()
    {
        string conn = SetDataBaseClass.SetDataBase(DataBaseName + ".db");
        IDbConnection dbcon;
        IDbCommand dbcmd;
        IDataReader reader;

        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();

        // Recupera o valor de "ID" usando PlayerPrefs
        int ID = PlayerPrefs.GetInt("ID", -1);
        // Recupera a variável "DataBaseName" usando PlayerPrefs

        string SQlQuery = "SELECT nome, moedas FROM users WHERE ID = @ID";
        dbcmd.Parameters.Add(new SqliteParameter("@ID", ID));

        dbcmd.CommandText = SQlQuery;
        reader = dbcmd.ExecuteReader();
        if (reader.Read())
        {
            string nome = reader.GetString(0);
            textName.text = nome;

            int moedas = reader.GetInt32(1); // Corrigido para usar GetInt32
            IntMoedas.text = moedas.ToString(); // Converte o inteiro para string
        }
        reader.Close();

        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;

    }
}