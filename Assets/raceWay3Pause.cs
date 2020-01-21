using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class raceWay3Pause : MonoBehaviour {

    public bool pauseBool;
    public GameObject pausePanel;
    public Button pauseButton;
    public Button resumeButton;
    public Button quitButton;

    void pauseGame()
    {
        if (!this.pauseBool)
        {
            Time.timeScale = 0f;
            this.pausePanel.SetActive(true);
            AudioListener.pause = true;
        }
        else
        {
            Time.timeScale = 1f;
            this.pausePanel.SetActive(false);
            AudioListener.pause = false;
        }

        this.pauseBool = !this.pauseBool;
    }

    void quitGame()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

	// Use this for initialization
	void Start () {

        pauseBool = false;
        this.pausePanel.SetActive(false);
        //print(this.GetComponent<pauseObject>().pauseBool);

        this.pauseButton.onClick.AddListener(pauseGame);
        this.resumeButton.onClick.AddListener(pauseGame);
        this.quitButton.onClick.AddListener(quitGame);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
