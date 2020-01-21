using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class csMainPanelScript : MonoBehaviour {


    public GameObject carPanelGrey;
    public GameObject carPanelRed;
    public GameObject carPanelBlue;
    public GameObject carPanelGreen;
	// Use this for initialization

    private IDbConnection conn;
	void Start () {

        this.carPanelGrey = GameObject.Find("greyImgPanel");
        this.carPanelRed = GameObject.Find("redImgPanel");
        this.carPanelBlue = GameObject.Find("blueImgPanel");
        this.carPanelGreen = GameObject.Find("greenImgPanel");

        this.carPanelGreen.GetComponent<Renderer>().enabled = false;

        // print(this.carPanelGrey);
        //initialize();
        init_db();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void initialize()
    {
        this.carPanelGrey.gameObject.SetActive(false);
        this.carPanelRed.gameObject.SetActive(false);
        this.carPanelBlue.gameObject.SetActive(false);
        this.carPanelGreen.gameObject.SetActive(false);

    }

    void init_db()
    {
        string conn_str = "URI=file:" + Application.dataPath + "/speedracer.db"; //Path to database.
        this.conn = (IDbConnection)new SqliteConnection(conn_str);


        this.conn.Open();
        IDbCommand dbcmd = this.conn.CreateCommand();
        string sqlQuery = "SELECT name, user_id FROM selections WHERE user_id LIKE \'" + (-2).ToString() + "\'";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Read();
        if (reader["name"].Equals("CAR_GREY"))
        {
            this.carPanelGrey.gameObject.SetActive(true);
        }
        else if (reader["name"].Equals("CAR_RED"))
        {
            this.carPanelRed.gameObject.SetActive(true);
        }
        else if (reader["name"].Equals("CAR_BLUE"))
        {
            this.carPanelBlue.gameObject.SetActive(true);
        }
        else if (reader["name"].Equals("CAR_GREEN"))
        {
            this.carPanelGreen.gameObject.SetActive(true);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        this.conn.Close();

    }
}
