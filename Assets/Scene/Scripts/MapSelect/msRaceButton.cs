using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

using Mono.Data.Sqlite;
using System.Data;
using System;
public class msRaceButton : MonoBehaviour {

    private IDbConnection conn;

	// Use this for initialization
	void Start () {
        this.GetComponent<Button>().onClick.AddListener(beginRace);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void beginRace() {
        //print("ehllo");
        string loadScene = "";
        string conn_str = "URI=file:" + Application.dataPath + "/speedracer.db"; //Path to database.
        this.conn = (IDbConnection)new SqliteConnection(conn_str);


        this.conn.Open();
        IDbCommand dbcmd = this.conn.CreateCommand();
        string sqlQuery = "SELECT name, user_id FROM selections WHERE user_id LIKE \'" + (-1).ToString() + "\'";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Read();
        if (reader["name"].Equals("TRACK1"))
        {
            loadScene = "RaceArea01";
        }
        else if (reader["name"].Equals("TRACK2"))
        {
            loadScene = "RaceArea02";
        }
        else if (reader["name"].Equals("TRACK3"))
        {
            loadScene = "RaceArea03";
        }
        else if (reader["name"].Equals("TRACK4"))
        {
            loadScene = "RaceArea04";
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        this.conn.Close();

        SceneManager.LoadScene(loadScene, LoadSceneMode.Single);
    }
}
