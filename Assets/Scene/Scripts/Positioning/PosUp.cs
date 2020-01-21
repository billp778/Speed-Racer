using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // for canvas display

public class PosUp : MonoBehaviour {

    public GameObject positionDisplay;

    void OnTriggerExit(Collider other) {
        // prevent other colliders colliding with the car's position in race
        print(other.tag);
        if (other.tag == "CarPos") {
            // telling the game we are in 1st place
            positionDisplay.GetComponent<Text>().text = "1st Place";
        }
    }
}
