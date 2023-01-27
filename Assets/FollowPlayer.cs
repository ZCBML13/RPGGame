using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == "Main Camera")
        {
            transform.position = player.transform.position + new Vector3(0, 6, -20);
        }
        else
        {
            transform.position = player.transform.position + new Vector3(0, 6,-20);
        }
    }
}