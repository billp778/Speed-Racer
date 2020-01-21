using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class csSlider : MonoBehaviour {

    public Slider mainSlider;
    public Text valueText;

    private IDbConnection conn;
   
	// Use this for initialization
	void Start () {
        this.mainSlider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
        //ValueChangeCheck();
        valueLoad();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void valueLoad()
    {
        string conn_str = "URI=file:" + Application.dataPath + "/speedracer.db"; //Path to database.
        this.conn = (IDbConnection)new SqliteConnection(conn_str);

        int changeTo = 0;
        this.conn.Open();
        IDbCommand dbcmd = this.conn.CreateCommand();
        string sqlQuery = "SELECT name, user_id FROM selections WHERE user_id LIKE \'" + (-3).ToString() + "\'";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Read();
        if (reader["name"].Equals("VERY_LIGHT"))
        {
            //this.mainSlider.value = 1;
            changeTo = 1;
            this.valueText.text = "Very Light";
            //this.carPanelRed.gameObject.SetActive(false);
        }
        else if (reader["name"].Equals("LIGHT"))
        {
            //this.mainSlider.value = 2;
            changeTo = 2;
            this.valueText.text = "Light";
            //this.carPanelRed.gameObject.SetActive(false);
        }
        else if (reader["name"].Equals("NORMAL"))
        {
            //this.mainSlider.value = 3;
            changeTo = 3;
            this.valueText.text = "Normal";
            //this.carPanelRed.gameObject.SetActive(false);
        }
        else if (reader["name"].Equals("HEAVY"))
        {
            //this.mainSlider.value = 4;
            changeTo = 4;
            this.valueText.text = "Heavy";
            //this.carPanelRed.gameObject.SetActive(false);
        }
        else if (reader["name"].Equals("VERY_HEAVY"))
        {
            //this.mainSlider.value = 5;
            changeTo = 5;
            this.valueText.text = "Very Heavy";
            //this.carPanelRed.gameObject.SetActive(false);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        this.conn.Close();

        this.mainSlider.value = changeTo;
    }

    public void ValueChangeCheck()
    {
        if (this.mainSlider.value == 1)
        {
            this.valueText.text = "Very Light";
            setDB("VERY_LIGHT");
        }
        else if (this.mainSlider.value == 2)
        {
            this.valueText.text = "Light";
            setDB("LIGHT");
        }
        else if (this.mainSlider.value == 3)
        {
            this.valueText.text = "Normal";
            setDB("NORMAL");
        }
        else if (this.mainSlider.value == 4)
        {
            this.valueText.text = "Heavy";
            setDB("HEAVY");
        }
        else if (this.mainSlider.value == 5)
        {
            this.valueText.text = "Very heavy";
            setDB("VERY_HEAVY");
        }
    }

    public void setDB(String setValue)
    {
        string conn_str = "URI=file:" + Application.dataPath + "/speedracer.db"; //Path to database.
        this.conn = (IDbConnection)new SqliteConnection(conn_str);


        this.conn.Open();
        IDbCommand dbcmd = this.conn.CreateCommand();
        string sqlQuery = "INSERT OR REPLACE INTO selections (id, name, user_id) VALUES (@id, @name, @user_id)";
        dbcmd.CommandText = sqlQuery;

        IDbDataParameter dp0 = dbcmd.CreateParameter();
        dp0.ParameterName = "id";
        dp0.Value = 4;
        dbcmd.Parameters.Add(dp0);

        IDbDataParameter dp = dbcmd.CreateParameter();
        dp.ParameterName = "name";
        dp.Value = setValue;
        dbcmd.Parameters.Add(dp);

        IDbDataParameter dp2 = dbcmd.CreateParameter();
        dp2.ParameterName = "user_id";
        dp2.Value = -3;
        dbcmd.Parameters.Add(dp2);

        dbcmd.ExecuteNonQuery();
        dbcmd.Dispose();
        dbcmd = null;
        this.conn.Close();
    }
}
