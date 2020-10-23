using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Matthew Makepeace
 * Student Number: 101179668
 * Last Modified: October 22, 2020
 * Source File Name: EnemyController.cs
 
 * Program Description: Enemy Controller script to control enemies movement, and to check if enemy is in bounds. 
        The Heart Pickup also uses this script, since the heart controlls, are similar to the enemy, but it has 
        no horizontal movement. only vertical
    

 * Modifications: * Enemy Movement, for it's horizontal direction and vertical down. 
                  * Enemy Check Bounds, to check if it's inbounds in the screen. If enemy is offscreen in bottom it moves
                    back up to the top offscreen.
     */

public class EnemyController : MonoBehaviour
{
    public float horizontalSpeed; // enemy speed
    public float horizontalBoundary; // enemy horizontal boundary

    public float verticalSpeed; // enemy vertical direction downwards

    private float direction;

    public GameObject enemy;

    private void Start()
    {
        int RandDirX = Random.Range(-1, 1); // Randomize the enemies horizontal direction.
        direction = RandDirX;

        if (direction == 0) // if the enemies horizontal direction is 0, direction will be 1, so enemy dosent move straight verticallly.
        {
            direction = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move() // enemy movement
    {
        transform.position += new Vector3(horizontalSpeed * direction * Time.deltaTime, verticalSpeed, 0.0f);
    }

    private void CheckBounds() // Enemy Check bounds, to check enemy is in bounds.
    {
        // Check Right Boundary
        if (transform.position.x >= horizontalBoundary)
        {
            direction = -1.0f;
        }

        // Check Left Boundary
        if (transform.position.x <= -horizontalBoundary)
        {
            direction = 1.0f;
        }

        if (transform.position.y <= -350.0f) // if the enemy is offscreen in the bottom, transform enemy back up in the top offscreen.
        {
            transform.Translate(0.0f, 3000.0f, 0.0f); // the enemy loops back up.
        }
    }
}
