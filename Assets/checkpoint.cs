using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{

    [SerializeField] int checkpointID = 0;
    [SerializeField] bool isFinishLine;

    private void Start()
    {

        if (checkpointID > trackStats.maxCheckpoints) { 
        
            trackStats.maxCheckpoints = checkpointID;
        
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<playerControl>() != null ) { 
        
            other.gameObject.GetComponent<playerControl>().checkpointNum = checkpointID;

            if (isFinishLine) {

                other.gameObject.GetComponent<playerControl>().numLap++;

                if (other.gameObject.GetComponent<playerControl>().numLap <= trackStats.maxlaps)
                {

                    other.gameObject.GetComponent<timer>().timerStop();
                    other.gameObject.GetComponent<timer>().timerStart();

                }

                else {

                    other.gameObject.GetComponent<timer>().timerStop();
                    trackStats.playerTime = other.gameObject.GetComponent<timer>().totalTime;
                    other.gameObject.GetComponent<timer>().enabled = false;

                }

            }
        
        }

    }

}
