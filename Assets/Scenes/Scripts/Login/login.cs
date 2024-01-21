using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;
using UnityEngine.Networking;
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

    void Start()
    {
        StartCoroutine(LoadDatabase());
    }

    IEnumerator LoadDatabase()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            pathToDB = Path.Combine(Application.streamingAssetsPath, DataBaseName);
            Debug.Log(pathToDB);
            Debug.Log(Application.persistentDataPath);
        }
        else
        {
            pathToDB = Path.Combine(Application.persistentDataPath, DataBaseName);

            if (!File.Exists(pathToDB))
            {
                string url = Path.Combine(Application.streamingAssetsPath, DataBaseName);
                UnityWebRequest www = UnityWebRequest.Get(url);

                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    File.WriteAllBytes(pathToDB, www.downloadHandler.data);
                }
                else
                {
                    Debug.LogError("Failed to load database: " + www.error);
                }
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