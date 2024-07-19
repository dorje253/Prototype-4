using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // A boolean flag to indicate if the enemy is a boss
    public bool isBoss = false;
    //The time interval between spawns for a boss enemy.
    public float spawnInterval;
    // The time at which the next spawn should occur.This is used to control the timing of mini-enemy spawns.
    private float nextSpawn;
    // This is used to control the timing of mini-enemy spawns.
    public int miniEnemySpawnCount;
    private SpawnManager spawnManager;

    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    
    // check if the enemy is a boss
        if (isBoss)
        {
            spawnManager = FindObjectOfType<SpawnManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position -transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
        // Checks if the current time is past the time when the next spawn should occur.
        if(isBoss)
        {
            if(Time.time > nextSpawn)
            {
                // to the time of the next spawn.
                nextSpawn = Time.time + spawnInterval;
                // Calls the number of mini-enemies to spawn.
                spawnManager.SpawnMiniEnemy(miniEnemySpawnCount);
            }
        }

        if(transform.position.y < -10){
            Destroy(gameObject);
        }
        if(transform.position.y >0){
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
