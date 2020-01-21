using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class Countdown : MonoBehaviour {

    public CarUserControl[] cars;

    public GameObject CountDown;
    public AudioSource GetReady;
    public AudioSource GoAudio;
    public GameObject LapTimer;
    public GameObject CarControls;
    // Music for Level Concept
    public AudioSource LevelMusic;

    void Start()
    {
        cars = GameObject.FindObjectsOfType<CarUserControl>();
        ToggleCarInput(false);
        StartCoroutine(CountStart());
    }


    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);

        // 3 animation
        CountDown.GetComponent<Text>().text = "3";
        GetReady.Play();
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);

        // 2 animation
        CountDown.GetComponent<Text>().text = "2";
        GetReady.Play();
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);

        // 1 animation
        CountDown.GetComponent<Text>().text = "1";
        GetReady.Play();
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        GoAudio.Play();
        LevelMusic.Play();
        LapTimer.SetActive(true);
        CarControls.SetActive(true);
        //enable car movement
        ToggleCarInput(true);
    }

    private void ToggleCarInput (bool enable)
    {
        if (cars == null) return;
        for (int i=0; i<cars.Length; i++)
        {
            cars[i].carMovementEnabled = enable;
            CarController.m_Topspeed = 200f;
        }

    }
}
