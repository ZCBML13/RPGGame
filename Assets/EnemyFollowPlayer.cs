using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    // Creates Variable for the target that the enemy is going to follow
    public GameObject target;
    // Creates Variable for the position of the player
    public Transform playerPosition;
    // Float for the speed of the enemy
    public float speed = 3f;
    // Boolean to check if the enemy is at the correct distance to shoot
    public bool correctDistance;
    // Float for what the Minimum distance from the player the enemy must be
    [SerializeField] private float MinDis = 25f;

    // When the object is created do this
    private void Awake()
    {
        // Finds a gameobject with the tag player and sets target to that
        target = GameObject.FindWithTag("Player");
        // Gets the position of the player from finding the player gameobject
        playerPosition = target.GetComponent<Transform>();
    }

    void Update()
    {
        // Subtracts the position of the ememy from the position of the player to find the distance between
        float distance = transform.position.x - playerPosition.position.x;

        // If the distance is greater than the minDis then continue
        if(distance > MinDis)
        {
            // The correct distance is incorrect
            correctDistance = false;
            // creates a float which finds how long to walk based on time for the same distance everytime
            float step = speed * Time.deltaTime;
            // Tells the enemy to move towards the target with a step
            transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, step);
        } 
        // if the distance is less then the mindis then continue
        else if (distance +3 < MinDis)
        {
            correctDistance = false;
            float step = speed * Time.deltaTime;
            // tells the enemy to run away from the target
            transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, -step);
        }
        // if the enemy is in the correct distance from the target 
        if (distance <= MinDis && distance >= MinDis -3)
        {
            // sets the bool correctDistance to true
            correctDistance = true;
        }
    }
}
