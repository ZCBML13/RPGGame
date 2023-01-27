using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // int for how many enemies each spawner can spawn
    public int EnemySpawnAmount = 6;
    // Float for the distance of the player from the spawner
    private float distance;
    // Int for how many enemies have been killed by each spawner
    private int AmountKilled;
    // Int For How many Enemies are allowed to be spawned at once depending on how many have been killed
    public int AmountAtOnce,AmountAtOnce2;
    // Int for how many enemies have to be killed until the AmountAtOnce2 is used
    public int HighSpawnRateAt;
    // Variables used to spawn the enemies at a random spot infront of the player
    public float min;
    public int max;

    // Variable used to copy and paste enemies
    public Rigidbody2D enemy;
    // Variables used to find the locations of the spawners and the player
    public Transform spawner;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        // Sets the min distance that the enemies can spawn to 30 away from the player
        min = player.position.x + 30;
        // sets the distance to the spawner position minus the player position
        distance = spawner.position.x - player.position.x;
        // Checks if the distance is correct and if the player still hasn't killed all the enemies in the spawner
        if(distance <= 20 && AmountKilled < EnemySpawnAmount)
        {
            // Checks if the amount of enemies active is less then the amount is allowed at once
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < AmountAtOnce)
            {
                // Creates a new enemy at the random location
                Instantiate(enemy, VectorCreater(min,max), spawner.rotation);
                // Adds one to the amount of enemies killed
                AmountKilled++;
            }
            // if the amount killed is higher then the amount for the high spawn amount to be started, continue
            if(AmountKilled > HighSpawnRateAt)
            {
                if (GameObject.FindGameObjectsWithTag("Enemy").Length < AmountAtOnce2)
                {
                    Instantiate(enemy, VectorCreater(min,max), spawner.rotation);
                    AmountKilled++;
                }
            }
        }
    }

    // RandomNumber generator 
    public float RandomNumber(float x,float y)
    {
        return Random.Range(x, y);
    }

    // Random location generator
    public Vector3 VectorCreater(float x,float y)
    {
        return new Vector3(RandomNumber(x, y), spawner.position.y, spawner.position.z);
    }
}
