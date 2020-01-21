using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mark17Script : MonoBehaviour
{
    public static int  Scores=0;
    public GameObject CheckPointCount;
    public GameObject Mark;
    public GameObject showLabel;

    public GameObject backPanel, startButton, endButton;

    void OnTriggerEnter(Collider collision)
    {
        this.Mark.SetActive(false);
        Scores++;
        CheckPointCount.GetComponent<Text>().text = ""+ Scores;
        Scores = 0;
        this.backPanel.SetActive(true);
        this.startButton.SetActive(false);
        this.endButton.SetActive(true);
        Time.timeScale = 0f;
        //showLabel.SetActive(true);
    }
}
