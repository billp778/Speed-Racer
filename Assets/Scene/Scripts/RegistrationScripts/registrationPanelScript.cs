using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class registrationPanelScript : MonoBehaviour {

    private Text errorMessage;

	// Use this for initialization
	void Start () {
        this.errorMessage = GameObject.Find("ErrorText").GetComponent<Text>();
        this.errorMessage.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
