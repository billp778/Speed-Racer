using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class backToLoginScript : MonoBehaviour {

    private 

	// Use this for initialization
	void Start () {
       this.GetComponent<Button>().onClick.AddListener(backToOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void backToOnClick() {
        SceneManager.LoadScene("Login", LoadSceneMode.Single);
    }
}
