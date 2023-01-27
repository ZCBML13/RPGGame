using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Variable for the Physics of the player
    public Rigidbody2D rb;

    // Float for the jumpheight and speed of the player
    public float speed, jumpHeight;
    // Bool to check if the player is touching the ground
    private bool isGrounded = false;
    // Float to find which direction the player is moving
    private float moveHorizontal;
    // Bool to find if the player is facing the right
    public bool isFacingRight = true;
    // Int for the Health of the player
    public int playerHealth = 100;

    // Bool for if the player can dash or not
    public bool canDash = true;
    // Bool for if the player is dashing
    private bool isDashing;
    // Float for dashing power of the dash, the time the player dashes for and the cooldown of the dash
    [SerializeField] private float dashingPower = 50f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;

    // Update is called once per frame
    void Update()
    {
        // if the player is dashing the program doesn't continue
        if (isDashing)
        {
            return;
        }
        
        // Sets moveHorizontal to a number between 1 and -1 depending on which direction the player wants to go
        moveHorizontal = Input.GetAxis("Horizontal");
        jump();
        Flip();
        // if the player has pressed the dash button and can dash then continue
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            // A coroutine is a way to call a function for a certain amount of time
            StartCoroutine(Dash());
        }

    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        // Sets the players velocity to the direction the player wants to go * the speed
        rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
    }

    // Method for the player to jump
    private void jump()
    {
        // if the player pressed space while on the ground, their y velocity is set to the jumpheight
        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpHeight);
        }
    }

    // Method for the player to flip based on which direction they are facing
    public void Flip()
    {
        // if they are facing right and press left or if they are facing left and press right then continue 
        if (isFacingRight && moveHorizontal < 0f || !isFacingRight && moveHorizontal > 0f)
        {
            // Creates a new variable called localScale which takes the current scale of the object(the direction they are facing)
            Vector3 localScale = transform.localScale;
            // makes the variable isFacingRight into the opposite
            isFacingRight = !isFacingRight;
            // makes the scale either negative or positive
            localScale.x *= -1;
            // Sets the players scale into the direction they want to face
            transform.localScale = localScale;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
    
    private IEnumerator Dash()
    {
        // sets canDash to false so the player can't dash twice in a row
        canDash = false;
        // Setes isDashing to true
        isDashing = true;
        // Creates a variable to keep the gravity scale of the player
        float originalGravity = rb.gravityScale;
        // sets the gravity to 0 so that the player doesn't fall while dashing
        rb.gravityScale = 0;
        // Adds velocity to the player based on there dashing power and which way they are facing
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        // Stops the program until the time it takes to dash has expired
        yield return new WaitForSeconds(dashingTime);
        // returns the gravity to the player
        rb.gravityScale = originalGravity;
        // sets isdashing to false
        isDashing = false;
        // Stops the code until the cooldown for the dash runs out
        yield return new WaitForSeconds(dashingCooldown);
        // Sets candash to true
        canDash = true;
    }
}
