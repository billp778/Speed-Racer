using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

using Mono.Data.Sqlite;
using System.Data;
using System;
public class msImageOne : MonoBehaviour {

    private GameObject trackPanelOne;
    private GameObject trackPanelTwo;
    private GameObject trackPanelThree;
    private GameObject trackPanelFour;

    private Text levelDesc;
    //private Text trackRec;
    private Text trackBest;

    // Use this for initialization
    void Start () {

        this.trackPanelOne = GameObject.Find("track1Panel");
        this.trackPanelTwo = GameObject.Find("track2Panel");
        this.trackPanelThree = GameObject.Find("track3Panel");
        this.trackPanelFour = GameObject.Find("track4Panel");

        this.levelDesc = GameObject.Find("levelDescription").GetComponent<Text>();
        //this.trackRec = GameObject.Find("trackRecords").GetComponent<Text>();
        this.trackBest = GameObject.Find("trackBestTimes").GetComponent<Text>();

        this.gameObject.AddComponent<ClickActionOne>();

        this.GetComponent<ClickActionOne>().setPanels(this.trackPanelOne, this.trackPanelTwo,
                                                        this.trackPanelThree, this.trackPanelFour,
                                                        this.levelDesc, /*this.trackRec,*/ this.trackBest);
	}

    public void setPanels(GameObject p1, GameObject p2, GameObject p3, GameObject p4) {
        this.trackPanelOne = p1;
        this.trackPanelTwo = p2;
        this.trackPanelThree = p3;
        this.trackPanelFour = p4;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class ClickActionOne : MonoBehaviour, IPointerClickHandler
{
    private GameObject trackPanelOne;
    private GameObject trackPanelTwo;
    private GameObject trackPanelThree;
    private GameObject trackPanelFour;

    private Text levelDesc;
    //private Text trackRec;
    private Text trackBest;

    private IDbConnection conn;

    public void OnPointerClick(PointerEventData eventData) {
        this.trackPanelOne.gameObject.SetActive(true);
        this.trackPanelTwo.gameObject.SetActive(false);
        this.trackPanelThree.gameObject.SetActive(false);
        this.trackPanelFour.gameObject.SetActive(false);

        // this needs to be moved into the DB
        this.levelDesc.text = "Track One";
        //this.trackRec.text = "Not Many records\nYou can handle This!";
        this.trackBest.text = "-- : -- : --     #1\n" +
                              "-- : -- : --     #2\n" +
                              "-- : -- : --     #3\n" +
                              "-- : -- : --     #4\n" +
                              "-- : -- : --     #5";

        setDBVals();
    }

    void setDBVals() {
        string conn_str = "URI=file:" + Application.dataPath + "/speedracer.db"; //Path to database.
        this.conn = (IDbConnection)new SqliteConnection(conn_str);


        this.conn.Open();
        IDbCommand dbcmd = this.conn.CreateCommand();
        string sqlQuery = "INSERT OR REPLACE INTO selections (id, name, user_id) VALUES (@id, @name, @user_id)";
        dbcmd.CommandText = sqlQuery;

        IDbDataParameter dp0 = dbcmd.CreateParameter();
        dp0.ParameterName = "id";
        dp0.Value = 1;
        dbcmd.Parameters.Add(dp0);

        IDbDataParameter dp = dbcmd.CreateParameter();
        dp.ParameterName = "name";
        dp.Value = "TRACK1";
        dbcmd.Parameters.Add(dp);

        IDbDataParameter dp2 = dbcmd.CreateParameter();
        dp2.ParameterName = "user_id";
        dp2.Value = -1;
        dbcmd.Parameters.Add(dp2);

        dbcmd.ExecuteNonQuery();
        dbcmd.Dispose();
        dbcmd = null;
        this.conn.Close();
    }

    public void setPanels(GameObject p1, GameObject p2, GameObject p3, GameObject p4, Text ld, /*Text tr,*/ Text tbt)
    {
        this.trackPanelOne = p1;
        this.trackPanelTwo = p2;
        this.trackPanelThree = p3;
        this.trackPanelFour = p4;

        this.levelDesc = ld;
        //this.trackRec = tr;
        this.trackBest = tbt;
    }
}
