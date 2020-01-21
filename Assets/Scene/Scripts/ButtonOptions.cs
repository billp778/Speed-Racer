using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// for changing between scenes
using UnityEngine.SceneManagement;

public class ButtonOptions : MonoBehaviour {
    public GameObject backPanel;
    // Main Menu
    public void MainMenu() {
        SceneManager.LoadScene(3);
    }
    // Car Select
    public void CarSelect() {
        SceneManager.LoadScene(4);
    }
    // RaceArea01
    public void Track1() {
        SceneManager.LoadScene(5);
    }
    // Map Select
    public void MapSelect() {
        SceneManager.LoadScene(6);
    }
    // RaceArea02
    public void Track2() {
        SceneManager.LoadScene(7);
    }
    // RaceArea03
    public void Track3() {
        SceneManager.LoadScene(8);
    }
    // RaceArea04
    public void Track4() {
        SceneManager.LoadScene(9);
    }
    // Test Track
    public void TestTrack() {
        //SceneManager.LoadScene(10);
        this.backPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void testTrackEnd() {
        SceneManager.LoadScene(10);
        Time.timeScale = 0f;
    }
    // Credits
    public void ViewCredits() {
        SceneManager.LoadScene(11);
    }
}
