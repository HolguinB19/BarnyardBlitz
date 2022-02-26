using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{

    float timeStarted;
    float lastLap;

    public Text lastLapText;
    public Text currentLapText;

    public float totalTime;

    bool timerActive;

    public void timerStart() {

        if (!timerActive)
        {

            timeStarted = Time.time;
            timerActive = true;

        }

    }

    public void timerStop() {

        if (timerActive)
        {

            totalTime += Time.time - timeStarted;
            timerActive = false;

        }
    
    }

    private void FixedUpdate()
    {

        if (timerActive)
        {
            
            currentLapText.text = "Current Lap: " + (Mathf.FloorToInt(Time.time - timeStarted) / 60).ToString() + ":" + Mathf.Repeat(Time.time - timeStarted, 60).ToString("0#.00");
            lastLapText.text = "Total Time: " + (Mathf.FloorToInt(totalTime + Time.time - timeStarted) / 60).ToString() + ":" + Mathf.Repeat(totalTime + Time.time - timeStarted, 60).ToString("0#.00");


        }

        else {

            currentLapText.text = "Current Lap: ";
            lastLapText.text = "Total Time: ";


        }
    }

}
