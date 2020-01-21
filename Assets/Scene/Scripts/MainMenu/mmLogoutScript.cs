using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class mmLogoutScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Button>().onClick.AddListener(logout);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void logout() {
        SceneManager.LoadScene("Login", LoadSceneMode.Single);
    }
}
