using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(timer))]

public class playerControl : MonoBehaviour
{

    public float speed;
    public float turnSpeed;
    Rigidbody rb;
    public int checkpointNum = trackStats.maxCheckpoints;
    public int numLap;
    Camera finishCam;
    Camera mainCamera;

    Text newBest;
    Text bestTime;
    Text thisTime;
    GameObject canvas;


    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
        rb.inertiaTensorRotation = Quaternion.identity;
        finishCam = gameObject.transform.GetChild(0).GetComponent<Camera>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        if (Mathf.Approximately(PlayerPrefs.GetFloat("bestTime"),0)) {

            PlayerPrefs.SetFloat("bestTime", 240);
        
        }

        canvas = GameObject.Find("Canvas");

        newBest = canvas.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        bestTime = canvas.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>();
        thisTime = canvas.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>();


    }

    private void Update()
    {

        if (canMove) {

            rb.AddForce(transform.forward * speed * Input.GetAxis("Vertical"), ForceMode.Acceleration);

            float temp = transform.eulerAngles.y;

            transform.eulerAngles = new Vector3(0, Input.GetAxis("Horizontal") + temp, 0);

        }

        if (numLap > trackStats.maxlaps) { 
        
            canMove = false;
            mainCamera.gameObject.SetActive(false);
            finishCam.gameObject.SetActive(true);

            float yourTime = GetComponent<timer>().totalTime;

            if (yourTime < PlayerPrefs.GetFloat("bestTime")) {

                PlayerPrefs.SetFloat("bestTime", yourTime);
                newBest.enabled = true;
            
            }

            canvas.transform.GetChild(0).GetComponent<Image>().enabled = true;

            bestTime.enabled = true;
            bestTime.text = "Best Time: " + (Mathf.FloorToInt(PlayerPrefs.GetFloat("bestTime")) / 60).ToString() + ":" + Mathf.Repeat(PlayerPrefs.GetFloat("bestTime"), 60).ToString("0#.00");

            thisTime.enabled = true;
            thisTime.text = "Your time: " + (Mathf.FloorToInt(yourTime) / 60).ToString() + ":" + Mathf.Repeat(yourTime, 60).ToString("0#.00");

        }


    }

}
