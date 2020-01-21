using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// for Lap Time text box in upper-right
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour {

    // Lap display variables
    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;
    public static string MilliDisplay;

    // UI variables
    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;

    public static float RawTime;

    public GameObject RaceFinish;


    // Update is called once per frame
    void Update()
    {
        if (!RaceFinish.activeSelf)
        {
            MilliCount += Time.deltaTime * 10;
            RawTime += Time.deltaTime;
            MilliDisplay = MilliCount.ToString("F0");
            MilliBox.GetComponent<Text>().text = "" + MilliDisplay;
            if (MilliCount >= 10)
            {
                MilliCount = 0;
                SecondCount += 1;
            }

            if (SecondCount <= 9)
            {
                SecondBox.GetComponent<Text>().text = "0" + SecondCount + ".";
            }
            else
            {
                SecondBox.GetComponent<Text>().text = "" + SecondCount + ".";
            }

            if (SecondCount >= 60)
            {
                SecondCount = 0;
                MinuteCount += 1;
            }

            if (MinuteCount <= 9)
            {
                MinuteBox.GetComponent<Text>().text = "0" + MinuteCount + ":";
            }
            else
            {
                MinuteBox.GetComponent<Text>().text = "" + SecondCount + ":";
            }
        }
    }
}
