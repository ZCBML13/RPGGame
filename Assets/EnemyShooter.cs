using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    // Variables for the dart and magic
    public Rigidbody2D dart;
    public Rigidbody2D magic;
    public Transform barrelEnd;
    // Variable for the script enemyfollowplayer
    public EnemyFollowPlayer enemy;

    // int for which weapon is being used
    private int weapon;
    // float for the speed of the projectiles
    public float speed;
    // float for the fire rate of the bow
    public float BowFireRate = 2f;
    // float for the fire rate of the Staff
    public float StaffFireRate = 4f;
    // float for a timer for when the weapon can fire next
    private float NextFire;

    // When the script is created pick a random number for which weapon is used
    private void Awake()
    {
        weapon = Random.Range(0, 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If the enemy is at the correct distance continue
        if (enemy.correctDistance)
        {
            // if the weapon selected is 0 and the time is less then when they can fire next, fire
            if(weapon == 0 && Time.time > NextFire)
            {
                shootDart();
                NextFire = Time.time + BowFireRate;
            }
            else if (weapon == 1 && Time.time > NextFire)
            {
                shootMagic();
                NextFire = Time.time + StaffFireRate;
            }
        }
    }

    // Funtion to create a dart 
    public void shootDart()
    {
        Rigidbody2D projectile = Instantiate(dart, barrelEnd.position, barrelEnd.rotation) as Rigidbody2D;
        projectile.AddForce(barrelEnd.right * -speed);
        NextFire = Time.time + BowFireRate;
    }

    // Funtion to create magic 
    public void shootMagic()
    {
        Rigidbody2D projectile = Instantiate(magic, barrelEnd.position, barrelEnd.rotation) as Rigidbody2D;
        projectile.AddForce(barrelEnd.right * -speed);
        NextFire = Time.time + StaffFireRate;
    }
}
