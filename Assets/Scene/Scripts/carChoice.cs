using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class carChoice : MonoBehaviour {

    public GameObject greyBody;
    public GameObject redBody;
    public GameObject blueBody;
    public GameObject greenBody;

    private IDbConnection conn;
	// Use this for initialization
	void Start () {
        string conn_str = "URI=file:" + Application.dataPath + "/speedracer.db"; //Path to database.
        this.conn = (IDbConnection)new SqliteConnection(conn_str);


        this.conn.Open();
        IDbCommand dbcmd = this.conn.CreateCommand();
        string sqlQuery = "SELECT name, user_id FROM selections WHERE user_id LIKE \'" + (-2).ToString() + "\'";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Read();
        if (reader["name"].Equals("CAR_GREY")) {
            this.greyBody.SetActive(true);
        } else if (reader["name"].Equals("CAR_RED")) {
            this.redBody.SetActive(true);
        } else if (reader["name"].Equals("CAR_BLUE")) {
            this.blueBody.SetActive(true);
        } else if (reader["name"].Equals("CAR_GREEN")) {
            this.greenBody.SetActive(true);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        this.conn.Close();		
	}

}
