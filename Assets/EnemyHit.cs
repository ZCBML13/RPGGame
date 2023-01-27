using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class EnemyHit : MonoBehaviour
{
    // Int for the health of enemies
    public int EnemyHealth = 40;
    // int for the damage that the enemies take
    public int dmg = 10;

    public SpriteRenderer EnemySprite;
    public GameObject Hero;
    // variable for the healthbar
    public HealthBar healthBar;

    private void Start()
    {
        Hero = GameObject.FindWithTag("Player");
        healthBar = Hero.GetComponent<HealthBar>();
    }
    // Update is called once per frame
    void Update()
    {
        // if the emeny's health is 0 or they fall off the map distroy them and heal the player for 50% of the health lost
        if (EnemyHealth <= 0 || transform.position.y < -45)
        {
            Destroy(gameObject);
            float missingHelath = 100 - healthBar.Health;
            healthBar.Health += missingHelath / 2;
        }
    }

    // If a projectile hits an enemy change the color to red then white again afte 0.1 sec
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AllyDart" || collision.gameObject.tag == "AllyMagic")
        {
            EnemySprite.color = Color.red;
            Invoke(nameof(TurnToWhite), .1f);
        }

        if (collision.gameObject.tag == "AllyDart")
        {
            EnemyHealth = EnemyHealth - dmg;
        }
        else if (collision.gameObject.tag == "AllyMagic")
        {
            EnemyHealth = EnemyHealth - dmg * 2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemySprite.color = Color.white;
    }

    public void TurnToWhite()
    {
        EnemySprite.color = Color.white;
    }
}