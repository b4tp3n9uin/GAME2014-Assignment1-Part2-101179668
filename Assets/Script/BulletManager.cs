using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Matthew Makepeace
 * Student Number: 101179668
 * Last Modified: October 22, 2020
 * Source File Name: Bullet Manager.cs
 
 * Program Description: Manages a queue of bullet pools. so that the bullets loops and gets reused, when it goes offscreen or hits the enemy.

 * Modifications:  * Created a queue of bullet pool.
                   * Created getters and Setters for the bullets in bullet pool.
     */

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public GameObject bullet;
    public int maxBullets;

    private Queue<GameObject> bulletPool;

    // Start is called before the first frame update
    void Start()
    {
        BuildBulletPool();
    }

    private void BuildBulletPool()
    {
        // Create Empty Queue Structure
        bulletPool = new Queue<GameObject>();

        for (int count = 0; count < maxBullets; count++) // Instansiate bullets in the pool.
        {
            var tempBullet = Instantiate(bullet);
            tempBullet.SetActive(false);
            bulletPool.Enqueue(tempBullet);
        }
    }

    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = bulletPool.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;

        return newBullet;
    }

    public void ReturnBullet(GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        bulletPool.Enqueue(returnedBullet);
    }
}
