using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUpdate : MonoBehaviour
{
    private const float Max_Health = 100;

    private float health;

    private Image healthBar;

    public HealthBar heal;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        health = heal.Health;
        healthBar.fillAmount = health / Max_Health;
    }
}
