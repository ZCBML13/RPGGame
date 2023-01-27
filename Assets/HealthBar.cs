using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Float for the Health of the player
    public float Health = 100;
    // Integar for how much damage the enimies can deal
    public int dmg = 20;
    // Varibale for the script UseShield to check if the player is using the shield 
    public UseShield shield;
    // Variable for the Enemy so they can be destoryed when the player dies
    public GameObject Enemy;

    // Update is called once per frame
    void Update()
    {
        // Checks if A GameObject With the Tag Enemy Is active and Attaches that game object to the variable Enemy
        Enemy = GameObject.FindWithTag("Enemy");
        // Checks if the players health is 0 or if they fell of the map
        if (Health <= 0 || transform.position.y < -45)
        {
            // Changes the posotion of the player to the starting position of the game
            transform.position = new Vector3(-15, -1,-5);
            // Sets the health of the player to 100
            Health = 100f;
            // Checks if any Enemies are alive and destroys them
            if (Enemy.activeInHierarchy)
            {
                Destroy(Enemy);
            }
        }
    }

    // Checks if anything has hit the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If an Enemy Dart Has hit the player continue
        if(collision.gameObject.tag == "EnemyDart")
        {
            // If the player is Blocking Subtract half the normal damgage from the players health
            if (shield.blocking)
            {
                Health -= dmg / 2;
                Debug.Log(Health);
            }
            // Else subtract the normal amount from the players health
            else
            {
                Health -= dmg;
                Debug.Log(Health);
            }
        } 
        // If the Enemies Magic Hit the player continue
        else if(collision.gameObject.tag == "EnemyMagic")
        {
            // If the player is Blocking Subtract half the normal damgage from the players health
            if (shield.blocking)
            {
                Health -= dmg;
                Debug.Log(Health);
            }
            // Else subtract the normal amount from the players health
            else
            {
                Health -= dmg * 2;
                Debug.Log(Health);
            }
        }
    }
}
