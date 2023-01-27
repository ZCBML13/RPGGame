using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour
{
    // Variable for Each of the texts that are shown to the players
    public TextMeshProUGUI Move, Jump,Goal,Weapons,Shield,Staff,Bow,Enemies,Dash,Cave;

    // Variable to find the Position of the player
    public Transform Hero;
    // Variables for the three scripts to find which class the player picked
    public PickUpWeapon Archer,Wizard,Soldier;

    // Update is called once per frame
    void Update()
    {// If statments that turn on or off the text on the screen based on the players position and which class they picked
        if(Hero.transform.position.x < 28)
        {
            Move.gameObject.SetActive(true);
            Jump.gameObject.SetActive(false);
            Goal.gameObject.SetActive(false);
            Weapons.gameObject.SetActive(false);
            Shield.gameObject.SetActive(false);
            Staff.gameObject.SetActive(false);
            Bow.gameObject.SetActive(false);
            Enemies.gameObject.SetActive(false);
            Dash.gameObject.SetActive(false);
            Cave.gameObject.SetActive(false);
        } 
        else if(Hero.transform.position.x > 28 && Hero.transform.position.x < 53)
        {
            Move.gameObject.SetActive(false);
            Jump.gameObject.SetActive(true);
            Goal.gameObject.SetActive(false);
            Weapons.gameObject.SetActive(false);
            Shield.gameObject.SetActive(false);
            Staff.gameObject.SetActive(false);
            Bow.gameObject.SetActive(false);
            Enemies.gameObject.SetActive(false);
            Dash.gameObject.SetActive(false);
            Cave.gameObject.SetActive(false);
        }
        else if (Hero.transform.position.x > 53 && Hero.transform.position.x < 65)
        {
            Move.gameObject.SetActive(false);
            Jump.gameObject.SetActive(false);
            Goal.gameObject.SetActive(true);
            Weapons.gameObject.SetActive(false);
            Shield.gameObject.SetActive(false);
            Staff.gameObject.SetActive(false);
            Bow.gameObject.SetActive(false);
            Enemies.gameObject.SetActive(false);
            Dash.gameObject.SetActive(false);
            Cave.gameObject.SetActive(false);
        }
        else if (Hero.transform.position.x > 65 && Hero.transform.position.x < 114 && !Soldier.Solider && !Wizard.Mage && !Archer.Archer)
        {
            Move.gameObject.SetActive(false);
            Jump.gameObject.SetActive(false);
            Goal.gameObject.SetActive(false);
            Weapons.gameObject.SetActive(true);
            Shield.gameObject.SetActive(false);
            Staff.gameObject.SetActive(false);
            Bow.gameObject.SetActive(false);
            Enemies.gameObject.SetActive(false);
            Dash.gameObject.SetActive(false);
            Cave.gameObject.SetActive(false);
        }
        else if (Soldier.Solider && Hero.transform.position.x < 114)
        {
            Move.gameObject.SetActive(false);
            Jump.gameObject.SetActive(false);
            Goal.gameObject.SetActive(false);
            Weapons.gameObject.SetActive(false);
            Shield.gameObject.SetActive(true);
            Staff.gameObject.SetActive(false);
            Bow.gameObject.SetActive(false);
            Enemies.gameObject.SetActive(false);
            Dash.gameObject.SetActive(false);
            Cave.gameObject.SetActive(false);
        }
        else if (Wizard.Mage && Hero.transform.position.x < 114)
        {
            Move.gameObject.SetActive(false);
            Jump.gameObject.SetActive(false);
            Goal.gameObject.SetActive(false);
            Weapons.gameObject.SetActive(false);
            Shield.gameObject.SetActive(false);
            Staff.gameObject.SetActive(true);
            Bow.gameObject.SetActive(false);
            Enemies.gameObject.SetActive(false);
            Dash.gameObject.SetActive(false);
            Cave.gameObject.SetActive(false);
        }
        else if (Archer.Archer && Hero.transform.position.x < 114)
        {
            Move.gameObject.SetActive(false);
            Jump.gameObject.SetActive(false);
            Goal.gameObject.SetActive(false);
            Weapons.gameObject.SetActive(false);
            Shield.gameObject.SetActive(false);
            Staff.gameObject.SetActive(false);
            Bow.gameObject.SetActive(true);
            Enemies.gameObject.SetActive(false);
            Dash.gameObject.SetActive(false);
            Cave.gameObject.SetActive(false);
        }
        else if (Hero.transform.position.x > 114 && Hero.transform.position.x < 155)
        {
            Move.gameObject.SetActive(false);
            Jump.gameObject.SetActive(false);
            Goal.gameObject.SetActive(false);
            Weapons.gameObject.SetActive(false);
            Shield.gameObject.SetActive(false);
            Staff.gameObject.SetActive(false);
            Bow.gameObject.SetActive(false);
            Enemies.gameObject.SetActive(true);
            Dash.gameObject.SetActive(false);
            Cave.gameObject.SetActive(false);
        }
        else if (Hero.transform.position.x > 200 && Hero.transform.position.x < 210)
        {
            Move.gameObject.SetActive(false);
            Jump.gameObject.SetActive(false);
            Goal.gameObject.SetActive(false);
            Weapons.gameObject.SetActive(false);
            Shield.gameObject.SetActive(false);
            Staff.gameObject.SetActive(false);
            Bow.gameObject.SetActive(false);
            Enemies.gameObject.SetActive(false);
            Dash.gameObject.SetActive(true);
            Cave.gameObject.SetActive(false);
        }
        else if (Hero.transform.position.x > 220 && Hero.transform.position.x < 280)
        {
            Move.gameObject.SetActive(false);
            Jump.gameObject.SetActive(false);
            Goal.gameObject.SetActive(false);
            Weapons.gameObject.SetActive(false);
            Shield.gameObject.SetActive(false);
            Staff.gameObject.SetActive(false);
            Bow.gameObject.SetActive(false);
            Enemies.gameObject.SetActive(false);
            Dash.gameObject.SetActive(false);
            Cave.gameObject.SetActive(true);
        }
        else
        {
            Move.gameObject.SetActive(false);
            Jump.gameObject.SetActive(false);
            Goal.gameObject.SetActive(false);
            Weapons.gameObject.SetActive(false);
            Shield.gameObject.SetActive(false);
            Staff.gameObject.SetActive(false);
            Bow.gameObject.SetActive(false);
            Enemies.gameObject.SetActive(false);
            Dash.gameObject.SetActive(false);
            Cave.gameObject.SetActive(false);
        }
    }
}
