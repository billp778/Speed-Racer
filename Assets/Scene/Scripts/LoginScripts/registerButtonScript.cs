using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Mono.Data.Sqlite;
using System.Data;
using System;


public class registerButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
        this.GetComponent<Button>().onClick.AddListener(onRegistrationClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onRegistrationClick() {
        SceneManager.LoadScene("Registration", LoadSceneMode.Single);
    }
}
