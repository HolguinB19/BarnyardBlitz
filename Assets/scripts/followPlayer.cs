using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{

    public GameObject player;

    public Vector3 offset;

    private void Update()
    {
        
        gameObject.transform.position = player.transform.position + offset;
        gameObject.transform.eulerAngles = new Vector3(90, player.transform.eulerAngles.y, 0);

    }

}
