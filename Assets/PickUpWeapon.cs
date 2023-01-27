using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public bool Archer,Mage,Solider;
    // Booleans for if the player is standing infront of each stand
    private bool InfrontOfArcherStand,InfrontOfWizardStand,InfrontOfSoldierStand;
    public PickUpWeapon bow, staff, shield;

    // Update is called once per frame
    void Update()
    {
        // if the player is standing infront of the archer stand and presses e, make the player an archer
        if (InfrontOfArcherStand)
        {
            if (Input.GetKeyDown("e"))
            {
                Archer = true;
                shield.Solider = false;
                staff.Mage = false;
            }
        }
        else if (InfrontOfSoldierStand)
        {
            if (Input.GetKeyDown("e"))
            {
                Solider = true;
                bow.Archer = false;
                staff.Mage = false;
            }
        }
        else if (InfrontOfWizardStand)
        {
            if (Input.GetKeyDown("e"))
            {
                Mage = true;
                shield.Solider = false;
                bow.Archer = false;
            }
        }
        
    }

    //Checks if the player collided with a stand
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (gameObject.name == "Archer Stand")
            {
                InfrontOfArcherStand = true;
            }
            else if (gameObject.name == "Wizard Stand")
            {
                InfrontOfWizardStand = true;
            }
            else if (gameObject.name == "Soldier Stand")
            {
                InfrontOfSoldierStand = true;
            }
        }
    }

    //Checks if the player has left the collision of the stand
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (gameObject.name == "Archer Stand")
            {
                InfrontOfArcherStand = false;
            }
            else if (gameObject.name == "Wizard Stand")
            {
                InfrontOfWizardStand = false;
            }
            else if (gameObject.name == "Soldier Stand")
            {
                InfrontOfSoldierStand = false;
            }
        }
    }
}
