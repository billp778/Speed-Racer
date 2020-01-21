using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class msCarSelectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Button>().onClick.AddListener(onCarSelectClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onCarSelectClick() {
        SceneManager.LoadScene("CarSelectionScene", LoadSceneMode.Single);
    }
}
