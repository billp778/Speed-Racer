using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Speedometer : MonoBehaviour
{
    //public GameObject car;
    public GameObject speedLabel;
    public Rigidbody car;
    public double currentCarSpeed;
	
	// Update is called once per frame
	void Update ()
    {
        currentCarSpeed= car.velocity.magnitude * 3.7;
        speedLabel.GetComponent<Text>().text = "Speed: " + (int)currentCarSpeed + " mph";
	}
}
