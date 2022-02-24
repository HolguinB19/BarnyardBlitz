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

    bool timerActive;

    private void Start()
    {

        lastLapText.text = PlayerPrefs.GetString("lastLap");

    }

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

            lastLap = Mathf.Round((Time.time - timeStarted) * 100.0f) * 0.01f;
            lastLapText.text = lastLap.ToString();
            PlayerPrefs.SetString("lastLap", lastLap.ToString());
            timerActive = false;

        }
    
    }

    private void FixedUpdate()
    {

        if (timerActive)
        {

            currentLapText.text = (Mathf.Round((Time.time - timeStarted) * 100.0f) * 0.01f).ToString();


        }

        else {

            currentLapText.text = "not active";


        }
    }

}
