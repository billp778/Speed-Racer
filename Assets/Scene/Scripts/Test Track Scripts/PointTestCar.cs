using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointTestCar : MonoBehaviour
{

    public GameObject TheMarker;
    public GameObject Mark01, Mark02, Mark03, Mark04, Mark05, Mark06, Mark07, Mark08, Mark09, Mark10;
    public GameObject Mark11, Mark12, Mark13, Mark14, Mark15, Mark16, Mark17;
    public GameObject backPanel, startButton, endButton;
    public int MarkTracker;

    //---
    public GameObject CheckpointCount;
    public bool finish = false;
    //---

    void Update()
    {
        if (MarkTracker == 0)
        {
            TheMarker.transform.position = Mark01.transform.position;
            if (finish == true)
            {
                CheckpointCount.GetComponent<Text>().text = "17";
            }
            else
            {
                CheckpointCount.GetComponent<Text>().text = "0";
            }
        }
        if (MarkTracker == 1)
        {
            TheMarker.transform.position = Mark02.transform.position;
            CheckpointCount.GetComponent<Text>().text = "1";
        }
        if (MarkTracker == 2)
        {
            TheMarker.transform.position = Mark03.transform.position;
            CheckpointCount.GetComponent<Text>().text = "2";
        }
        if (MarkTracker == 3)
        {
            TheMarker.transform.position = Mark04.transform.position;
            CheckpointCount.GetComponent<Text>().text = "3";
        }
        if (MarkTracker == 4)
        {
            TheMarker.transform.position = Mark05.transform.position;
            CheckpointCount.GetComponent<Text>().text = "4";
        }
        if (MarkTracker == 5)
        {
            TheMarker.transform.position = Mark06.transform.position;
            CheckpointCount.GetComponent<Text>().text = "5";
        }
        if (MarkTracker == 6)
        {
            TheMarker.transform.position = Mark07.transform.position;
            CheckpointCount.GetComponent<Text>().text = "6";
        }
        if (MarkTracker == 7)
        {
            TheMarker.transform.position = Mark08.transform.position;
            CheckpointCount.GetComponent<Text>().text = "7";
        }
        if (MarkTracker == 8)
        {
            TheMarker.transform.position = Mark09.transform.position;
            CheckpointCount.GetComponent<Text>().text = "8";
        }
        if (MarkTracker == 9)
        {
            TheMarker.transform.position = Mark10.transform.position;
            CheckpointCount.GetComponent<Text>().text = "9";
        }
        if (MarkTracker == 10)
        {
            TheMarker.transform.position = Mark11.transform.position;
            CheckpointCount.GetComponent<Text>().text = "10";
        }
        if (MarkTracker == 11)
        {
            TheMarker.transform.position = Mark12.transform.position;
            CheckpointCount.GetComponent<Text>().text = "11";
        }
        if (MarkTracker == 12)
        {
            TheMarker.transform.position = Mark13.transform.position;
            CheckpointCount.GetComponent<Text>().text = "12";
        }
        if (MarkTracker == 13)
        {
            TheMarker.transform.position = Mark14.transform.position;
            CheckpointCount.GetComponent<Text>().text = "13";
        }
        if (MarkTracker == 14)
        {
            TheMarker.transform.position = Mark15.transform.position;
            CheckpointCount.GetComponent<Text>().text = "14";
        }
        if (MarkTracker == 15)
        {
            TheMarker.transform.position = Mark16.transform.position;
            CheckpointCount.GetComponent<Text>().text = "15";
        }
        if (MarkTracker == 16)
        {
            TheMarker.transform.position = Mark17.transform.position;
            CheckpointCount.GetComponent<Text>().text = "16";
            //print("Hello");
        }
        if (MarkTracker == 17)
        {
            //CheckpointCount.GetComponent<Text>().text = "17";
            //print("Hello");
        }
    }

    IEnumerator OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<BoxCollider>().enabled = false;
            MarkTracker += 1;
            if (MarkTracker == 17)
            {
                finish = true;
                MarkTracker = 0;
                this.backPanel.SetActive(true);
                this.startButton.SetActive(false);
                this.endButton.SetActive(true);
                Time.timeScale = 0f;
                //CheckpointCount.GetComponent<Text>().text = "17";
                //TheMarker.transform.position = Mark01.transform.position;
            }
            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }
}