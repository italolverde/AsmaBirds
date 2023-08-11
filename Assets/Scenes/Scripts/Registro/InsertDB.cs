using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using Mono.Data;
using System.Data;

public class InsertDB : MonoBehaviour
{
    public string dbName;
    public void Inserir()
    {
        string conn = SetDataBaseClass.SetDataBase(dbName + ".db");
        IDbConnection dbcon;
        IDbCommand dbcmd;
        IDataReader reader;

        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        string SqlQuery = "Enter your query";
        dbcmd.CommandText = SqlQuery;
        reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {

        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
    }


}
