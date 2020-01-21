using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCheckpoints : MonoBehaviour
{
    public GameObject Mark;
    //---
    public GameObject CheckPointCount;
    //---

    void OnTriggerEnter(Collider collision)
    {
        this.Mark.SetActive(false);
        Mark17Script.Scores++;
        CheckPointCount.GetComponent<Text>().text = "" + Mark17Script.Scores;

    }

}