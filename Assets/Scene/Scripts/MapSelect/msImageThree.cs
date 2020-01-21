using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

using Mono.Data.Sqlite;
using System.Data;
using System;
public class msImageThree : MonoBehaviour {

    public GameObject trackPanelOne;
    public GameObject trackPanelTwo;
    public GameObject trackPanelThree;
    public GameObject trackPanelFour;

    private Text levelDesc;
   // private Text trackRec;
    private Text trackBest;

    // Use this for initialization
    void Start () {
        GameObject panel = GameObject.Find("MapPanel");
        msMainPanel panelScript = panel.GetComponent<msMainPanel>();

        this.trackPanelOne = panelScript.trackPanelOne;
        this.trackPanelTwo = panelScript.trackPanelTwo;
        this.trackPanelThree = panelScript.trackPanelThree;
        this.trackPanelFour = panelScript.trackPanelFour;

        this.levelDesc = GameObject.Find("levelDescription").GetComponent<Text>();
        //this.trackRec = GameObject.Find("trackRecords").GetComponent<Text>();
        this.trackBest = GameObject.Find("trackBestTimes").GetComponent<Text>();

        this.gameObject.AddComponent<ClickActionThree>();

        this.GetComponent<ClickActionThree>().setPanels(this.trackPanelOne, this.trackPanelTwo,
                                                        this.trackPanelThree, this.trackPanelFour,
                                                        this.levelDesc, /*this.trackRec,*/ this.trackBest);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class ClickActionThree : MonoBehaviour, IPointerClickHandler
{
    private GameObject trackPanelOne;
    private GameObject trackPanelTwo;
    private GameObject trackPanelThree;
    private GameObject trackPanelFour;

    private Text levelDesc;
    private Text trackRec;
    private Text trackBest;

    private IDbConnection conn;

    public void OnPointerClick(PointerEventData eventData)
    {
        this.trackPanelOne.gameObject.SetActive(false);
        this.trackPanelTwo.gameObject.SetActive(false);
        this.trackPanelThree.gameObject.SetActive(true);
        this.trackPanelFour.gameObject.SetActive(false);

        // this needs to be moved into the DB
        this.levelDesc.text = "Track Three";
        //this.trackRec.text = "Tons of records\nHave Fun!";
        this.trackBest.text = "02 : 12 : 01     #1\n" +
                              "02 : 34 : 10     #2\n" +
                              "01 : 44 : 90     #3\n" +
                              "02 : 12 : 78     #4\n" +
                              "03 : 23 : 98     #5";

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
        dp.Value = "TRACK3";
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
