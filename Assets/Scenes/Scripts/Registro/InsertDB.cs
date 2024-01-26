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

public class InsertDB : MonoBehaviour
{
    public InputField NameInput;
    public InputField SobrenomeInput;
    public InputField EmailInput;
    public InputField PasswordInput;
    public string DataBaseName;
    public Text CadastroStatus;
    private IDbConnection dbcon;
    private string pathToDB;

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

    public void InsertInto()
    {
        var _NameInput = NameInput.text.Trim();
        var _SobrenomeInput = SobrenomeInput.text.Trim();
        var _EmailInput = EmailInput.text.Trim();
        var _PasswordInput = PasswordInput.text.Trim();

        if (string.IsNullOrEmpty(_NameInput) || string.IsNullOrEmpty(_SobrenomeInput) ||
            string.IsNullOrEmpty(_EmailInput) || string.IsNullOrEmpty(_PasswordInput))
        {
            CadastroStatus.text = "Todos os campos devem ser preenchidos.";
            return;
        }

        if (_EmailInput.Length < 7)
        {
            CadastroStatus.text = "E-mail inválido. O email deve ter pelo menos 7 caracteres.";
            return;
        }

        if (_PasswordInput.Length < 8)
        {
            CadastroStatus.text = "A senha deve ter pelo menos 8 caracteres.";
            return;
        }

        string conn = SetDataBaseClass.SetDataBase(DataBaseName + ".db");
        IDbConnection dbcon;
        IDbCommand dbcmd;

        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        string SQlQuery = "Insert Into Users(nome, sobrenome, email, senha)" +
                          "Values('" + _NameInput + "', '" + _SobrenomeInput + "', '" + _EmailInput + "', '" + _PasswordInput + "')";
        dbcmd.CommandText = SQlQuery;

        try
        {
            dbcmd.ExecuteNonQuery();
            Debug.Log("Inserção bem-sucedida.");
            LoadScenes("Loginteste");
        }
        catch (System.Exception)
        {
            CadastroStatus.text = "E-mail já cadastrado";
        }

        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
    }

    public void LoadScenes(string cena)
    {
        SceneManager.LoadScene(cena);
    }

}