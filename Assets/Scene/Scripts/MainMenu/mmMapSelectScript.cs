using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class mmMapSelectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Button>().onClick.AddListener(goToMapSelect);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void goToMapSelect()
    {
        SceneManager.LoadScene("MapSelection", LoadSceneMode.Single);
    }
}
