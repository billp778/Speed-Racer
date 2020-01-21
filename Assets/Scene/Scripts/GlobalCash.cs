using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // for text implmentation

public class GlobalCash : MonoBehaviour {

    public int CashValue;
    public static int TotalCash;
    public GameObject CashDisplay;

    void Start() {
        TotalCash = PlayerPrefs.GetInt("SavedCash");
    }


    void Update() {
        // make cash value same as the total
        CashValue = TotalCash;
        // assign new cash value every time race completes
        CashDisplay.GetComponent<Text>().text = "Cash $" + CashValue;
    }
}
