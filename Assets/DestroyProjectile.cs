using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    // variable for the width of the screen
    public float ScreenWidth = 12.5f;
    // variable for the player gameobject
    public GameObject shield;
    // variable for the shield script
    public UseShield use;
    
    // When the game object is created it finds the shield script from the player gameobject
    private void Awake()
    {
        shield = GameObject.FindWithTag("Player");
        use = shield.GetComponent<UseShield>();
    }

    void Update()
    {
        // if the projectile goes our side of the cameras FOV it gets destroyed
        if (transform.position.x > Camera.main.transform.position.x + ScreenWidth || transform.position.x < Camera.main.transform.position.x - ScreenWidth)
        {
            Destroy(gameObject);
        }
    }

    // If the players projectille hits an enemy it is destroyed
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "AllayMagic" || gameObject.tag == "AllayDart")
        {
            if(collision.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
        }
        // If an enemies projectile hits the player while they aren't blocking it is destroyed
        if (gameObject.tag == "EnemyMagic" || gameObject.tag == "EnemyDart")
        {
            if (!use.blocking)
            {
                if (collision.gameObject.tag == "Player")
                {
                    Destroy(gameObject);
                }
            }
            
        }
        // if any projectile hits the floor it is destroyed
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
