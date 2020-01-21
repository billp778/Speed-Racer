using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class loginButtonScript : MonoBehaviour {

    private Text usernameField;
    private IDbConnection conn;
    private Text errorMessage;

	// Use this for initialization
	void Start () {

        this.errorMessage = GameObject.Find("ErrorText").GetComponent<Text>();

        string conn_str = "URI=file:" + Application.dataPath + "/speedracer.db"; //Path to database.
        this.conn = (IDbConnection)new SqliteConnection(conn_str);

        this.usernameField = GameObject.Find("loginText").GetComponent<Text>();
        this.GetComponent<Button>().onClick.AddListener(onButtonClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onButtonClick() {
        //print(this.usernameField.text.ToString());
        string username = this.usernameField.text.ToString();
        if (username != null && !username.Equals("")) {
            this.conn.Open();
            IDbCommand dbcmd = this.conn.CreateCommand();
            string sqlQuery = "SELECT id FROM users WHERE username LIKE \'" + username + "\'";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            reader.Read();
            if (reader["id"] == DBNull.Value) {
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                this.conn.Close();
                this.errorMessage.enabled = true;
                this.errorMessage.fontSize = 24;
                this.errorMessage.text = "Username: " + username + " Does Not Exist";
            } else {
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                this.conn.Close();
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }

        } else {
            this.errorMessage.enabled = true;
            this.errorMessage.text = "Enter Login Information";
        }
    }
}
