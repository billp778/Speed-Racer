using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loginPanelScript : MonoBehaviour {

    public GameObject loginfield;
    public GameObject loginbutton;
    private Text errorMessage;
    private Text successMessage;

	// Use this for initialization
	void Start () {
        //print(loginField.text);
        //this.loginfield = this.gameObject.transform.GetChild(3).gameObject;
        //this.loginbutton = this.gameObject.transform.GetChild(0).gameObject;

        this.errorMessage = GameObject.Find("ErrorText").GetComponent<Text>();
        this.errorMessage.enabled = false;

        this.successMessage = GameObject.Find("SuccessText").GetComponent<Text>();
        this.successMessage.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onLoginClick()
    {
        //print(GameObject.Find("loginText").GetComponent<Text>().text.ToString());
    }
}
