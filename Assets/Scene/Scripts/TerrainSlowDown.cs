using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class TerrainSlowDown : MonoBehaviour
{
    private bool UseTerrainSlowDown;

    private const bool showLogs = true;

    public CarController m_Car;

    private void Start()
    {
        UseTerrainSlowDown = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "RaceArea02";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (UseTerrainSlowDown)
        {
            if (other.gameObject.tag != "Road")
            {
              if (showLogs) Debug.Log("enter != road");
                m_Car.isOffroad = true;
            }
            else if (other.gameObject.tag == "Road")
            {
                if (showLogs) Debug.Log("enter: road");
                m_Car.isOffroad = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (UseTerrainSlowDown)
        {
            if (other.gameObject.tag == "Road")
            {
                if (showLogs) Debug.Log("exit: road");
                m_Car.isOffroad = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (UseTerrainSlowDown)
        {
            if (other.gameObject.tag == "Road")
            {
                if (showLogs) Debug.Log("trigger stay : road");
                m_Car.isOffroad = false;
            }
        }
    }


    /*
    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag != "Road")
        {
            Debug.Log("I am Off road");
            m_Car.isOffroad = true;
        }
        else
        {
            Debug.Log("I am on road");
            m_Car.isOffroad = false;
        }

    }
    */
}
