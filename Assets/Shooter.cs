using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Rigidbody2D dart;
    public Rigidbody2D magic;
    public Transform barrelEnd;
    public PickUpWeapon PickUpBow;
    public PickUpWeapon PickUpStaff;
    public CharacterMovement hero;

    // Float for the speed for the projectile
    public float speed;
    // Float for Fire Rate of bow and staff
    private float BowFireRate = .5f;
    private float StaffFireRate = 1f;
    // Float for when the weapon can fire next
    private float NextFire;


    void Update()
    {
        Flip();

        // if the player picked the archer class continue
        if (PickUpBow.Archer)
        {
            shootDart();
        }
        // if the player picked the mage class continue
        else if (PickUpStaff.Mage)
        {
            shootMagic();
        }
    }

    private void shootDart()
    {
        // if the LMB is pressed and the time is less then when they can fire next continue
        if (Input.GetMouseButtonDown(0) && Time.time > NextFire)
        {
            Rigidbody2D projectile = Instantiate(dart, barrelEnd.position, barrelEnd.rotation) as Rigidbody2D;
            projectile.AddForce(barrelEnd.right * speed);
            NextFire = Time.time + BowFireRate;
        }
    }

    private void shootMagic()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > NextFire)
        {
            Rigidbody2D projectile = Instantiate(magic, barrelEnd.position, barrelEnd.rotation) as Rigidbody2D;
            projectile.AddForce(barrelEnd.right * speed);
            NextFire = Time.time + StaffFireRate;
        }
    }

    private void Flip()
    {
        // Checks if the player is facing right, if not then make the projectile go in a negative direction
        if (hero.isFacingRight && speed < 0 || !hero.isFacingRight && speed > 0)
        {
            speed *= -1;
        }
    }
}
