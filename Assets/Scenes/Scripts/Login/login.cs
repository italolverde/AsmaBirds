using UnityEngine;
using System.Collections;
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
    private IDbConnection dbcon;

    void Start()
    {
        string databasePath = Path.Combine(Application.streamingAssetsPath, "Users.db");
        StartCoroutine(LoadDatabase(databasePath));
    }

    IEnumerator LoadDatabase(string dbPath)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            // No Android, copie o banco de dados para Application.persistentDataPath onde ele pode ser acessado
            string persistentPath = Path.Combine(Application.persistentDataPath, "Users.db");
            if (!File.Exists(persistentPath))
            {
                UnityWebRequest www = UnityWebRequest.Get(dbPath);
                yield return www.SendWebRequest();
                if (www.result == UnityWebRequest.Result.Success)
                {
                    File.WriteAllBytes(persistentPath, www.downloadHandler.data);
                    dbPath = persistentPath;
                }
                else
                {
                    Debug.LogError("Failed to load database: " + www.error);
                    yield break;
                }
            }
            else
            {
                dbPath = persistentPath;
            }
        }

        // Agora dbPath contém o caminho correto para o banco de dados em todas as plataformas
        ConnectToDatabase(dbPath);
    }

    private void ConnectToDatabase(string dbPath)
    {
        string connectionString = "URI=file:" + dbPath;
        dbcon = new SqliteConnection(connectionString);

        try
        {
            dbcon.Open();
            Debug.Log("Connected to database.");
        }
        catch (Exception ex)
        {
            Debug.LogError("Error connecting to database: " + ex.Message);
        }
    }

    public void InsertLogin()
    {
        string _EmailInput = EmailInput.text.Trim();
        string _PasswordInput = PasswordInput.text.Trim();

        try
        {
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                string sqlQuery = "SELECT count(*) FROM Users WHERE email=@Email AND senha=@Password";
                dbcmd.CommandText = sqlQuery;
                dbcmd.Parameters.Add(new SqliteParameter("@Email", _EmailInput));
                dbcmd.Parameters.Add(new SqliteParameter("@Password", _PasswordInput));

                int result = Convert.ToInt32(dbcmd.ExecuteScalar());

                if (result > 0)
                {
                    sqlQuery = "SELECT ID FROM Users WHERE email=@Email AND senha=@Password";
                    dbcmd.CommandText = sqlQuery;
                    using (IDataReader reader = dbcmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int ID = reader.GetInt32(0);
                            PlayerPrefs.SetInt("ID", ID);
                        }
                        reader.Close();
                    }

                    LoginStatus.text = "Login realizado com sucesso";
                    SceneManager.LoadScene("Menu_principal");
                }
                else
                {
                    LoginStatus.text = "Email ou senha invÃ¡lido";
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error on login: " + ex.Message);
            LoginStatus.text = "Erro ao tentar logar.";
        }
    }

    void OnDestroy()
    {
        if (dbcon != null)
        {
            dbcon.Close();
            dbcon = null;
        }
    }
}