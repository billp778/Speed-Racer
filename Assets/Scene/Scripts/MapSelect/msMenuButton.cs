using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class msMenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Button>().onClick.AddListener(mainButtonClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void mainButtonClick() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
