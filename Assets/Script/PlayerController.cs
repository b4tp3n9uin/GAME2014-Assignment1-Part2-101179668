using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Matthew Makepeace
 * Student Number: 101179668
 * Last Modified: October 22, 2020
 * Source File Name: PlayerController.cs
 
 * Program Description: This script is for the player controller. It controlls the player movements,
        Collision Detections that involves the player, lives counter, player spawning bullets, and boundary checks.

 * Modifications: * Player's movement controls to go towards the horizontal direction on the players touch. 
                  * Added a bullet manager object and made a function for the player to fire bullets.
                  * Player's checkBounds, to make sure player dosen't go offscreeen.
                  * Set players' lives with the hearts at the top of the screen.
     */

public class PlayerController : MonoBehaviour
{
    // float for the players speed.
    public float moveSpeed = 1.0f;
    // Player rigidbody
    public Rigidbody2D rigidBody;
    // Bulletmanager to make bullets spawn where the player is
    public BulletManager bulletMgr;

    // Player lives.
    int lives = 2;

    public float horizontalBoundary; // Boundary for player, so it dosen't move offscreen 
    public float horizontalSpeed; // player horizontal speed
    public float maxSpeed; // player maximum speed.
    public float horizontalTValue;

    private Vector3 touchEnd; // Touch position

    public GameObject h1, h2, h3; // This represents the player's lives at the top of the screen

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        touchEnd = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        checkBounds();
        FireBullet();

        switch (lives) // Switch statement to show the number of lives you have on the screen.
        {
            case 1:
                h1.gameObject.SetActive(true);
                h2.gameObject.SetActive(false);
                h3.gameObject.SetActive(false);
                break;
            case 2:
                h1.gameObject.SetActive(true);
                h2.gameObject.SetActive(true);
                h3.gameObject.SetActive(false);
                break;
            case 3:
                h1.gameObject.SetActive(true);
                h2.gameObject.SetActive(true);
                h3.gameObject.SetActive(true);
                break;
            case 0:
                h1.gameObject.SetActive(false);
                h2.gameObject.SetActive(false);
                h3.gameObject.SetActive(false);
                break;
        }

    }

    private void FireBullet()
    {
        // Delay Bullet Firing by 60 frames
        if (Time.frameCount % 60 == 0)
        {
            bulletMgr.GetBullet(transform.position);
        }
    }

    private void Move() //function for the player's horizontal movement
    {
        // player initial direction
        float direction = 0.0f;

        foreach (var touch in Input.touches) 
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.position.x > transform.position.x)
            {
                direction = 1.0f;
            }

            if (touch.position.x < transform.position.x)
            {
                direction = -1.0f;
            }

            touchEnd = worldTouch;
        }

        if (touchEnd.x != 0)
        {
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, touchEnd.x, horizontalTValue), transform.position.y);
            Vector2.Lerp(transform.position, touchEnd, 0.1f);
        }
        else
        {
            Vector2 newVelocity = rigidBody.velocity + new Vector2(direction * horizontalSpeed, 0.0f);
            rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            rigidBody.velocity *= 0.99f;
        }
    }

    private void checkBounds() // function to check if the player is off bounds.
    {
        // check rightbound
        if (transform.position.x >= horizontalBoundary)
        {
            transform.position = new Vector3(horizontalBoundary, transform.position.y, 0.0f);
        }

        // check leftbound
        if (transform.position.x <= -horizontalBoundary)
        {
            transform.position = new Vector3(-horizontalBoundary, transform.position.y, 0.0f);
        }
    }


    public void OnTriggerEnter2D(Collider2D other) // Collision detection to check if the player collides with the enemy or heart pickup.
    {
        if (other.gameObject.tag.Equals("Enemy")) // Player Enemy Collision
        {
            FindObjectOfType<AudioManager>().Play("Die"); // sound
            lives--; // lose a live
            Debug.Log("Lives: " + lives);

            if (lives == 0) // you have no lifes, GAME OVER!
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        if (other.gameObject.tag.Equals("Pickup")) // Player Heart Collision
        {
            FindObjectOfType<AudioManager>().Play("LifePickup"); // sound
            if (lives < 3) // player can't exceed 3 lives.
            {              // If you have less than 3 lives, increment.
                lives++;
            }
            Debug.Log("Lives: " + lives);
            ScoreScript.score += 50; // you gain 50 points for picking up the heart! 
            Destroy(other.gameObject);
        }
    }
}
