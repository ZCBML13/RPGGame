using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KingSquareEnd : MonoBehaviour
{
    // Bool used to see if player is touching King Square at the end
    private bool EndGame;
    // Varibale of end text so it can be actiavted when game is over
    public TextMeshProUGUI text;
    // Variable for the BackGround of the game over screen
    public GameObject BG;
    // Variable for the Health Bar
    public Image image;

    // Update is called once per frame
    void Update()
    {
        // Checks if an enemy is alive, if not then continue
        if(GameObject.FindWithTag("Enemy") == null)
        {
            // If the player is touching King Square continue
            if (EndGame)
            {
                // Activate the BackGround of the game over screen, the text and turn off the health bar
                BG.gameObject.SetActive(true);
                text.gameObject.SetActive(true);
                image.gameObject.SetActive(false);
                // Stops time in the game so the player can't move around
                Time.timeScale = 0;
            }
        }
    }

    // Checks if there is a collsion with King Square and an Object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If King Square is colliding with the player then continue
        if(collision.gameObject.tag == "Player")
        {
            // Boolean to say that the game can end
            EndGame = true;
        }
    }

    // Checks if a collider has left collision with King Square
    private void OnTriggerExit2D(Collider2D collision)
    {
        // If the player continue
        if (collision.gameObject.tag == "Player")
        {
            // Boolean to say that the game can Not end
            EndGame = false;
        }
    }
}
