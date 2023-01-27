using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCave : MonoBehaviour
{
    private bool InfrontOfCave;
    private bool InsideCave;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        // if the player is standing infront of the cave
        if (InfrontOfCave)
        {
            // if the player is inside the cave and presses e, then teleport them outside
            if (InsideCave)
            {
                if (Input.GetKeyDown("e"))
                {
                    Debug.Log(InsideCave);
                    InsideCave = false;
                    player.position = new Vector3(266, 11,-5);
                    Debug.Log(InsideCave);
                }
            }
            else if (!InsideCave)
            {
                if (Input.GetKeyDown("e"))
                {
                    Debug.Log(InsideCave);
                    InsideCave = true;
                    player.position = new Vector3(1303, 177,-5);
                    Debug.Log(InsideCave);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            InfrontOfCave = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InfrontOfCave = false;
        }
    }
}
