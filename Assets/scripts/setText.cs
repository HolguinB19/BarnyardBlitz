using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setText : MonoBehaviour
{

    public Text text;

    public void Update()
    {

        if (PlayerPrefs.GetString("lastTime") != "")
        {

            text.text = PlayerPrefs.GetString("lastTime");

        }

        else {

            text.text = "no data";
        
        }

    }

}
