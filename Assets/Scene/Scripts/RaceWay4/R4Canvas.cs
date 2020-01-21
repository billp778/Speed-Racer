using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R4Canvas : MonoBehaviour {

    public GameObject quitPanel;

	// Use this for initialization
	void Start () {
        this.quitPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        print(Input.GetKeyDown("escape"));
        if (Input.GetKeyDown("space"))
        {
            this.quitPanel.SetActive(true);
        }
	}
}
