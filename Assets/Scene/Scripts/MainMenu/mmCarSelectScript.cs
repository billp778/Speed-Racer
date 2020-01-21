using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class mmCarSelectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Button>().onClick.AddListener(goToCarSelect);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void goToCarSelect()
    {
        SceneManager.LoadScene("CarSelectionScene", LoadSceneMode.Single);
    }
}
