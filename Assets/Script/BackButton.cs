using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Matthew Makepeace
 * Student Number: 101179668
 * Last Modified: September 26, 2020
 * Source File Name: BackButton.cs

 * Program Description: Script for the Main Menu Button Behaviour to take the
   user to the Main Menu Scene.

 * Modifications: NONE
     */

public class BackButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Event handler for the OnBackButtonPressed event
    public void OnBackButtonPressed()
    {
        Debug.Log("Back Button Pressed!");
        //ScoreScript.score = 0;
        SceneManager.LoadScene("Start");
    }
}
