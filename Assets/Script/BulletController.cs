using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletController : MonoBehaviour
{
/*
 * Author: Matthew Makepeace
 * Student Number: 101179668
 * Last Modified: October 22, 2020
 * Source File Name: BulletController.cs
 
 * Program Description: Bullet Controlls on it's movement, check if it's offbounds at the top, and collision detection check with Enemy.

 * Modifications: * Bullet movement to shoot vetically upwards
                  * Check Bounds to see if the bullet
                  * Collsion Detection to see if bullet collides with enemy.
     */

    public float verticalSpeed;
    public float verticalBoundary;

    public BulletManager bulletMgr; // Bullet Manager

    // Start is called before the first frame update
    void Start()
    {
        bulletMgr = FindObjectOfType<BulletManager>(); // Set up a bullet manager.
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move() // Bullet Movement
    {
        transform.position += new Vector3(0.0f, verticalSpeed, 0.0f);
    }

    private void CheckBounds() // Bullet Checkbounds to see if it's offscreen on top.
    {
        if (transform.position.y > verticalBoundary)
        {
            bulletMgr.ReturnBullet(gameObject); // Return the bullet to the Bullet Queue if it's offscreen.
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);
        

        if (other.gameObject.tag.Equals("Enemy")) // Bullet and Enemy Collision
        {
            FindObjectOfType<AudioManager>().Play("KillEnemy"); // sound
            Destroy(other.gameObject); // destroy enemy
            ScoreScript.score += 10; // if you killed enemy you get 10 points.
            bulletMgr.ReturnBullet(gameObject); // Bullet is returned to Bullet Queue after it collides with enemy.
        }
    }
}
