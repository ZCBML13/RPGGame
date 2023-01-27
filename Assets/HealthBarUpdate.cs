using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUpdate : MonoBehaviour
{
    // Variable for the max health a player could have
    private const float Max_Health = 100;

    // float for the health of the player right now
    private float health;

    // variable for the healthbar on your screen
    private Image healthBar;

    // variable for the healthbar script
    public HealthBar heal;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // every frame the image on your screen is updated with the current health of the player by divding it by the total health then filling the image by that percentage
        health = heal.Health;
        healthBar.fillAmount = health / Max_Health;
    }
}
