using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public EnemyHit enemy;
    public GameObject Object;
    private bool InfrontOfChest;

    // Update is called once per frame
    void Update()
    {
        // if the player is infront of the chest and presses e then set the dmg to 20
        if (InfrontOfChest)
        {
            if (Input.GetKeyDown("e"))
            {
                gameObject.SetActive(false);
                enemy.dmg = 20;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InfrontOfChest = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InfrontOfChest = false;
        }
    }
}
