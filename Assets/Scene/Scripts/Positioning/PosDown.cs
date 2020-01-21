using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PosDown : MonoBehaviour {

    public GameObject positionDisplay;

    void OnTriggerExit(Collider other) {
        // prevent other colliders colliding with the car's position in race
        if (other.tag == "CarPos") {
            // telling the game we are in 2nd place
            positionDisplay.GetComponent<Text>().text = "2nd Place";
        }
    }
}
