using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Mono.Data.Sqlite;
using System.Data;
using System;
public class mmMainOpen : MonoBehaviour {

    private RawImage mapImage;
    private RawImage carImage;
    private Texture2D map = null;
    private Texture2D carSkin = null;

    private IDbConnection conn;

	// Use this for initialization
	void Start () {
        this.mapImage = GameObject.Find("currentMapSelect").GetComponent<RawImage>();
        this.carImage = GameObject.Find("carSelected").GetComponent<RawImage>();
        //print(Application.dataPath);

        string conn_str = "URI=file:" + Application.dataPath + "/speedracer.db"; //Path to database.
        this.conn = (IDbConnection)new SqliteConnection(conn_str);


        this.conn.Open();
        IDbCommand dbcmd = this.conn.CreateCommand();
        string sqlQuery = "SELECT name, user_id FROM selections WHERE user_id LIKE \'" + (-1).ToString() + "\'";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Read();
        if (reader["name"].Equals("TRACK1")) {
            this.map = this.LoadPNG(Application.dataPath + "/Textures/TrackThumbnail/raceArea01Thumb.png");
        } else if (reader["name"].Equals("TRACK2")) {
            this.map = this.LoadPNG(Application.dataPath + "/Textures/TrackThumbnail/raceArea02Thumb.png");
        } else if (reader["name"].Equals("TRACK3")) {
            this.map = this.LoadPNG(Application.dataPath + "/Textures/TrackThumbnail/raceArea03Thumb.png");
        } else if (reader["name"].Equals("TRACK4")) {
            this.map = this.LoadPNG(Application.dataPath + "/Textures/TrackThumbnail/raceArea04Thumb.png");
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        this.conn.Close();

        this.mapImage.texture = this.map;

        this.conn.Open();
        IDbCommand dbcmd2 = this.conn.CreateCommand();
        string sqlQuery2 = "SELECT name, user_id FROM selections WHERE user_id LIKE \'" + (-2).ToString() + "\'";
        dbcmd2.CommandText = sqlQuery2;
        IDataReader reader2 = dbcmd2.ExecuteReader();
        reader2.Read();

        if (reader2["name"].Equals("CAR_GREY"))
        {
            this.carSkin = this.LoadPNG(Application.dataPath + "/Textures/CarThumb/Grey.png");
        }
        else if (reader2["name"].Equals("CAR_RED"))
        {
            this.carSkin = this.LoadPNG(Application.dataPath + "/Textures/CarThumb/carRed.png");
        }
        else if (reader2["name"].Equals("CAR_BLUE"))
        {
            this.carSkin = this.LoadPNG(Application.dataPath + "/Textures/CarThumb/carBlue.png");
        }
        else if (reader2["name"].Equals("CAR_GREEN"))
        {
            this.carSkin = this.LoadPNG(Application.dataPath + "/Textures/CarThumb/Green.png");
        }
        reader2.Close();
        reader2 = null;
        dbcmd2.Dispose();
        dbcmd2 = null;
        this.conn.Close();

        this.carImage.texture = this.carSkin;
	}

    public Texture2D LoadPNG(string filePath)
    {

        Texture2D tex = null;
        byte[] fileData;

        if (System.IO.File.Exists(filePath))
        {
            fileData = System.IO.File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
