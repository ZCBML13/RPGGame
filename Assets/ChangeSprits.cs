using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprits : MonoBehaviour
{
    // Used so that you can specify which SpriteRender You are using
    public SpriteRenderer hero;
    // Different Sprit variables for each of the sprits
    public Sprite MageSprite, ArcherSprite, SoldierSprite;
    // Different variables for each of the scripts to find which class is being used
    public PickUpWeapon Staff, Shield, Bow;


    // Update is called once per frame
    void Update()
    {
        //If the player picked the mage class from the Staff Script, Change the sprite of the player to a wizard
        if (Staff.Mage)
        {
            ChangeSprit(MageSprite);
        }
        //If the player picked the Soldier class from the Shield Script, Change the sprite of the player to a soldier
        else if (Shield.Solider)
        {
            ChangeSprit(SoldierSprite);
        }
        //If the player picked the Archer class from the Bow Script, Change the sprite of the player to a Archer
        else if (Bow.Archer)
        {
            ChangeSprit(ArcherSprite);
        }
    }

    // Function to change the sprite of the player to the sprite the code passed in
    void ChangeSprit(Sprite sprite)
    {
        hero.sprite = sprite;
    }
}
