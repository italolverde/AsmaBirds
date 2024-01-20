using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour
{
    public InputField EmailInput;
    public InputField PasswordInput;
    public string DataBaseName;
    public Text LoginStatus;
    private string pathToDB;

    private void Start()
    {
        ConnectionDB ();
    }

    void ConnectionDB()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            pathToDB = Application.dataPath + "/StreamingAssets/" + DataBaseName;
        }
        else
        {
            pathToDB = Application.persistentDataPath + "/" + DataBaseName;

            if (!File.Exists(pathToDB))
            {
                WWW load = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DataBaseName);
                while (!load.isDone) { }

                File.WriteAllBytes(pathToDB, load.bytes);
            }
        }
    }

    public void InsertLogin()
    {
        string _EmailInput = EmailInput.text.Trim();
        string _PasswordInput = PasswordInput.text.Trim();
        string conn = SetDataBaseClass.SetDataBase(DataBaseName + ".db");
        IDbConnection dbcon;
        IDbCommand dbcmd;
        IDataReader reader;

        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();

        // checa se existe o usuario
        string SQlQuery = "Select count(*) from Users where email='" + _EmailInput + "' and senha='" + _PasswordInput + "'";
        dbcmd.CommandText = SQlQuery;
        int result = Convert.ToInt32(dbcmd.ExecuteScalar());

        if (result > 0)
        {
            // se existir, pega o id do usuario
            SQlQuery = "Select ID from Users where email='" + _EmailInput + "' and senha='" + _PasswordInput + "'";
            dbcmd.CommandText = SQlQuery;
            reader = dbcmd.ExecuteReader();
            if (reader.Read())
            {
                int ID = reader.GetInt32(0);
                PlayerPrefs.SetInt("ID", ID);
            }
            reader.Close();

            LoginStatus.text = "Login realizado com sucesso";
            SceneManager.LoadScene("Menu_principal");
        }
        else
        {
            LoginStatus.text = "Email ou senha inválido";
        }

        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
    }
}