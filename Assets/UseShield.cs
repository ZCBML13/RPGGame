using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UseShield : MonoBehaviour
{
    // Floats for the Original speed of the player and half of it
    private float originalSpeed, halfOfSpeed;
    // Boolean for if the player is blocking or not
    public bool blocking;
    // String To check which Projectile was shot at the player
    private string ProjectileTag;
    // Float for the speed of the projectile
    public float ProjectileSpeed;


    // Variable for the Sprite of the player
    public SpriteRenderer player;
    // Varibale for shield Script to check if the player picked the soldier class
    public PickUpWeapon PickUpShield;
    // Variable for the movement script of the player
    public CharacterMovement movement;
    //Variable for a copy of the enemies dart and magic
    public Rigidbody2D dart;
    public Rigidbody2D magic;
    // Variable for the location that the projectiles will be returned from
    public Transform barrelEnd;

    // Start is called at the begining of the game
    private void Start()
    {
        // Sets the variable OriginalSpeed to the speed of the player and halfOfSpeed to half of that
        originalSpeed = movement.speed;
        halfOfSpeed = movement.speed / 2;
    }
    // Update is called once per frame
    void Update()
    {
        // Checks if the player picked the soldier class
        if (PickUpShield.Solider)
        {
            // Checks if the player Pressed down the LMB
            if (Input.GetMouseButtonDown(0))
            {
                // Sets the color of the player to blue to show that they are blocking
                player.color = Color.blue;
                // sets the blocking variable to true
                blocking = true;

            }
            // Checks if the player let go of the LMB
            if (Input.GetMouseButtonUp(0))
            {
                // Sets the color of the player to white to show that they stopped blocking
                player.color = Color.white;
                // Set the blocking variable to false
                blocking = false;
            }

            // Checks if the player is blocking
            if (blocking)
            {
                // Halves the players movement speed and doesn't let them block
                movement.speed = halfOfSpeed;
                movement.canDash = false;
            }
            //Checks if the player stopped blocking
            else if (!blocking)
            {
                // Returns the players speed to normal and allows the player to dash
                movement.speed = originalSpeed;
                movement.canDash = true;
            }
        }
    }

    // Checks if something has hit the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player is blocking continue
        if (blocking)
        {
            // Checks if an enemy dart or magic has hit the player
            if (collision.gameObject.tag == "EnemyMagic" || collision.gameObject.tag == "EnemyDart")
            {
                // Records which projectile hit the player
                ProjectileTag = collision.gameObject.tag;
                // Destorys the projectile
                Destroy(collision.gameObject);
                // Picks a random number, either 0 or 1, if 0 continue
                if (RandomInt() == 0)
                {
                    // if the enemy shot a dart continue
                    if (ProjectileTag == "EnemyDart")
                    {
                        // A new Dart is created at the BarrelEnd Location and pointing the same way as it
                        Rigidbody2D projectile = Instantiate(dart, barrelEnd.position, barrelEnd.rotation) as Rigidbody2D;
                        // Adds force to the projectile based on the speed picked
                        projectile.AddForce(barrelEnd.right * ProjectileSpeed);
                    }
                    // If a dart wasn't shot at the player then magic must have been shot
                    else
                    { 
                        Rigidbody2D projectile = Instantiate(magic, barrelEnd.position, barrelEnd.rotation) as Rigidbody2D;
                        projectile.AddForce(barrelEnd.right * ProjectileSpeed);
                    }
                }
                else
                {
                    Debug.Log("missed");
                }
            }
        }
    }

    // Funtion that picks a random number of eithe 0 or 1
    private int RandomInt()
    {
        return Random.Range(0, 2);
    }

}
