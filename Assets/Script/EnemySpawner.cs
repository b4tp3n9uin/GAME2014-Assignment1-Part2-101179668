using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Matthew Makepeace
 * Student Number: 101179668
 * Last Modified: October 22, 2020
 * Source File Name: EnemySpawner.cs
 
 * Program Description: Spawns the enemy offscreen on top. This script is also used for the Heart Spawner.

 * Modifications:  * Set the enemy's spawn location, spawn rate, and instanciate the enemies spawn.
     */

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    float randX;

    Vector2 spawnLocation;

    public float spawnRate;

    float nextSpawn = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-613.0f, 613.0f); // This is the random ranges of where the enemy can spawn in the screen.
            spawnLocation = new Vector2(randX, transform.position.y); // Spawn location of the enemy

            Instantiate(enemy, spawnLocation, Quaternion.identity); // Instantiate the spawned Enemy at the spawned location
        }
    }
}
