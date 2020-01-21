using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.UI; // to access dialogue box in canvas

public class RaceFinish : MonoBehaviour
{

    public GameObject MyCar;
    public GameObject FinishCam;
    public GameObject ViewModes;
    public GameObject LevelMusic;
    public GameObject CompleteTrig;
    public AudioSource FinishMusic;

    public GameObject OptionsBox;

    // post race pop up box
    void Start() {
        StartCoroutine(PopUpWindow());
    }

    // once finish line is crossed
    void OnTriggerEnter()
    {
      
        this.GetComponent<BoxCollider>().enabled = false;
        MyCar.SetActive(false);
        CompleteTrig.SetActive(false);
        CarController.m_Topspeed = 0.0f;
        MyCar.GetComponent<CarController>().enabled = false;
        MyCar.GetComponent<CarUserControl>().enabled = false;
        MyCar.SetActive(true);
        FinishCam.SetActive(true);
        LevelMusic.SetActive(false);
        ViewModes.SetActive(false);
        FinishMusic.Play();
        GlobalCash.TotalCash += 100;
        PlayerPrefs.SetInt("SavedCash", GlobalCash.TotalCash);
    }

    /* function that waits tens seconds before displaying an options
       box to the player to select a different option, or race again
    */
    IEnumerator PopUpWindow() {
        yield return new WaitForSeconds(10);
        OptionsBox.SetActive(true);
    }
}
