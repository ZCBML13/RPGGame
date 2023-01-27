using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    public float ScreenWidth = 12.5f;
    public GameObject shield;
    public UseShield use;

    private void Awake()
    {
        shield = GameObject.FindWithTag("Player");
        use = shield.GetComponent<UseShield>();
    }

    void Update()
    {
        if (transform.position.x > Camera.main.transform.position.x + ScreenWidth || transform.position.x < Camera.main.transform.position.x - ScreenWidth)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "AllayMagic" || gameObject.tag == "AllayDart")
        {
            if(collision.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
        }
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
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
