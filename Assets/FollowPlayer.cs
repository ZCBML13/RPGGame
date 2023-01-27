using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // variable for the position of the player
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        // if the object using this script is a camera then set its position to the players plus the selected distance from the player
        if(gameObject.name == "Main Camera")
        {
            transform.position = player.transform.position + new Vector3(0, 6, -20);
        }
        // if the object using this script is anything else then set its position to the players plus the selected distance from the player
        else
        {
            transform.position = player.transform.position + new Vector3(0, 6,-20);
        }
    }
}
