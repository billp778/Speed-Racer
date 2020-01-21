using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // for canvas objects

public class TestTrackBegin : MonoBehaviour {

    public GameObject Checkpoints;

	// start function
	void Start () {
        StartCoroutine(TestBegin());
    }
	
    /* have start button visible at beginning 
     * of test track only. Freeze frame of background
     * w/ vehicle until "Start" clicked
     */
	IEnumerator TestBegin() {

        yield return new WaitForSeconds(0.1f);
 
        Checkpoints.SetActive(false);
    }
}
