using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class registrationButtonScript : MonoBehaviour {

    private Text desiredUsername;
    private Text confirmUsername;
    private Text errorMessage;
    private IDbConnection conn;
	// Use this for initialization
	void Start () {
        string conn_str = "URI=file:" + Application.dataPath + "/speedracer.db"; //Path to database.
        this.conn = (IDbConnection)new SqliteConnection(conn_str);

        this.desiredUsername = GameObject.Find("desiredText").GetComponent<Text>();
        this.confirmUsername = GameObject.Find("confirmText").GetComponent<Text>();

        this.GetComponent<Button>().onClick.AddListener(createUser);

        this.errorMessage = GameObject.Find("ErrorText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Create User
    void createUser() {
        string dUsername = this.desiredUsername.text.ToString();
        string cUsername = this.confirmUsername.text.ToString();
        if (dUsername != null && !dUsername.Equals("") && dUsername.Equals(cUsername)) {
            this.conn.Open();
            IDbCommand dbcmd = this.conn.CreateCommand();
            string sqlQuery = "SELECT id FROM users WHERE username LIKE \'" + dUsername + "\'";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            reader.Read();
            if (reader["id"] != DBNull.Value) {
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                this.conn.Close();
                //print("Username Already Exists");
                this.errorMessage.enabled = true;
                this.errorMessage.fontSize = 24;
                this.errorMessage.text = "Username: " + dUsername + " Already Exists";
            } else {
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                this.conn.Close();
                this.addUser();
                print("Added User");
            }
        } else if (dUsername == null || dUsername.Equals("")) {
            this.errorMessage.enabled = true;
            this.errorMessage.fontSize = 20;
            this.errorMessage.text = "Enter Login Information";
        } else {
            this.errorMessage.enabled = true;
            this.errorMessage.fontSize = 20;
            this.errorMessage.text = "Desired Confirm Do Not Match";
        }
    }

    void addUser() {
        string dUsername = this.desiredUsername.text.ToString();
        //print(dUsername);
        this.conn.Open();
        IDbCommand dbcmd = this.conn.CreateCommand();
        string sqlQuery = "INSERT INTO users (username) VALUES (@username)";
        dbcmd.CommandText = sqlQuery;
        IDbDataParameter dp = dbcmd.CreateParameter();
        dp.ParameterName = "username";
        dp.Value = dUsername;
        dbcmd.Parameters.Add(dp);
        dbcmd.ExecuteNonQuery();
        dbcmd.Dispose();
        dbcmd = null;
        this.conn.Close();
        SceneManager.LoadScene("Login", LoadSceneMode.Single);
    }
}
