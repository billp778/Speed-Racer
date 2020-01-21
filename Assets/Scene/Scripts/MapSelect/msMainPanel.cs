using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class msMainPanel : MonoBehaviour {


    public GameObject trackPanelOne;
    public GameObject trackPanelTwo;
    public GameObject trackPanelThree;
    public GameObject trackPanelFour;

    private IDbConnection conn;

	// Use this for initialization
	void Start () {
        this.trackPanelOne = GameObject.Find("track1Panel");
        this.trackPanelTwo = GameObject.Find("track2Panel");
        this.trackPanelThree = GameObject.Find("track3Panel");
        this.trackPanelFour = GameObject.Find("track4Panel");

        initialize();

        //GameObject panel = GameObject.Find("track1Panel");
        //msImageOne panelScript = this.trackPanelOne.GetComponent<msImageOne>();
        //print(panelScript);
        //panelScript.setPanels(this.trackPanelOne, this.trackPanelTwo, this.trackPanelThree, this.trackPanelFour);

        init_db();

	}

    void initialize() {
        this.trackPanelOne.gameObject.SetActive(false);
        this.trackPanelTwo.gameObject.SetActive(false);
        this.trackPanelThree.gameObject.SetActive(false);
        this.trackPanelFour.gameObject.SetActive(false);

    }

    void init_db() {
        string conn_str = "URI=file:" + Application.dataPath + "/speedracer.db"; //Path to database.
        this.conn = (IDbConnection)new SqliteConnection(conn_str);

        
        this.conn.Open();
        IDbCommand dbcmd = this.conn.CreateCommand();
        string sqlQuery = "SELECT name, user_id FROM selections WHERE user_id LIKE \'" + (-1).ToString() + "\'";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Read();
        if (reader["name"].Equals("TRACK1")) {
            this.trackPanelOne.gameObject.SetActive(true);
        } else if (reader["name"].Equals("TRACK2")) {
            this.trackPanelTwo.gameObject.SetActive(true);
        } else if (reader["name"].Equals("TRACK3")) {
            this.trackPanelThree.gameObject.SetActive(true);
        } else if (reader["name"].Equals("TRACK4")) {
            this.trackPanelFour.gameObject.SetActive(true);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        this.conn.Close();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
