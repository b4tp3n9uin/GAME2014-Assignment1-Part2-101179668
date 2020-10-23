using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Matthew Makepeace
 * Student Number: 101179668
 * Last Modified: October 22, 2020
 * Source File Name: StartButton.cs
 
 * Program Description: Script for the Play Button Behaviour to take the
   user to the Game Level Scene.

* Modifications: * When Play Button is pressed, set score to 0.
     */

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Event handler for the On StartButtonPressed event
    public void OnStartButtonPressed()
    {
        Debug.Log("Start Button Pressed!");
        ScoreScript.score = 0; // When Start Button is pressed, reset the score to 0.
        SceneManager.LoadScene("Play");
    }

}
