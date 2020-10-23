using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Matthew Makepeace
 * Student Number: 101179668
 * Last Modified: September 26, 2020
 * Source File Name: GameOverButton.cs 
 
 * Program Description: Script for the Game Over Button Behaviour to take the
   user to the Game Over Scene.

 * Modifications: NONE
     */

public class GameOverButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Event handler for the OnGameOverButtonPressed event
    public void OnGameOverButtonPressed()
    {
        Debug.Log("GameOver Button Pressed!");
        SceneManager.LoadScene("GameOver");
    }
}
