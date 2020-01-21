using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using UnityEngine.EventSystems;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class csGreyCarScript : MonoBehaviour {

    public GameObject carPanelGrey;
    public GameObject carPanelRed;
    public GameObject carPanelBlue;
    public GameObject carPanelGreen;

    private Text carDesc;
    private IDbConnection conn;
	// Use this for initialization
	void Start () {
        this.carPanelGrey = GameObject.Find("greyImgPanel");
        this.carPanelRed = GameObject.Find("redImgPanel");
        this.carPanelBlue = GameObject.Find("blueImgPanel");
        this.carPanelGreen = GameObject.Find("greenImgPanel");

        this.carDesc = GameObject.Find("carOptText").GetComponent<Text>();

        this.gameObject.AddComponent<ClickActionGrey>();

        this.GetComponent<ClickActionGrey>().setPanels(this.carPanelGrey, this.carPanelRed,
                                                        this.carPanelBlue, this.carPanelGreen,
                                                        this.carDesc);

        //initialize();
	}

    void initialize()
    {
        string conn_str = "URI=file:" + Application.dataPath + "/speedracer.db"; //Path to database.
        this.conn = (IDbConnection)new SqliteConnection(conn_str);


        this.conn.Open();
        IDbCommand dbcmd = this.conn.CreateCommand();
        string sqlQuery = "SELECT name, user_id FROM selections WHERE user_id LIKE \'" + (-2).ToString() + "\'";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Read();
        if (!reader["name"].Equals("CAR_GREY"))
        {
            this.carPanelGrey.gameObject.SetActive(false);
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

public class ClickActionGrey : MonoBehaviour, IPointerClickHandler
{
    private GameObject carPanelGrey;
    private GameObject carPanelRed;
    private GameObject carPanelBlue;
    private GameObject carPanelGreen;

    private Text carDesc;

    private IDbConnection conn;

    public void OnPointerClick(PointerEventData eventData)
    {
        this.carPanelGrey.gameObject.SetActive(true);
        this.carPanelRed.gameObject.SetActive(false);
        this.carPanelBlue.gameObject.SetActive(false);
        this.carPanelGreen.gameObject.SetActive(false);

        // this needs to be moved into the DB
        this.carDesc.text = "A Car with a GREY body";

        setDBVals();
    }

    void setDBVals()
    {
        string conn_str = "URI=file:" + Application.dataPath + "/speedracer.db"; //Path to database.
        this.conn = (IDbConnection)new SqliteConnection(conn_str);


        this.conn.Open();
        IDbCommand dbcmd = this.conn.CreateCommand();
        string sqlQuery = "INSERT OR REPLACE INTO selections (id, name, user_id) VALUES (@id, @name, @user_id)";
        dbcmd.CommandText = sqlQuery;

        IDbDataParameter dp0 = dbcmd.CreateParameter();
        dp0.ParameterName = "id";
        dp0.Value = 3;
        dbcmd.Parameters.Add(dp0);

        IDbDataParameter dp = dbcmd.CreateParameter();
        dp.ParameterName = "name";
        dp.Value = "CAR_GREY";
        dbcmd.Parameters.Add(dp);

        IDbDataParameter dp2 = dbcmd.CreateParameter();
        dp2.ParameterName = "user_id";
        dp2.Value = -2;
        dbcmd.Parameters.Add(dp2);

        dbcmd.ExecuteNonQuery();
        dbcmd.Dispose();
        dbcmd = null;
        this.conn.Close();
    }

    public void setPanels(GameObject p1, GameObject p2, GameObject p3, GameObject p4, Text ld)
    {
        this.carPanelGrey = p1;
        this.carPanelRed = p2;
        this.carPanelBlue = p3;
        this.carPanelGreen = p4;

        this.carDesc = ld;
    }
}
