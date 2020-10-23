using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author: Matthew Makepeace
 * Student Number: 101179668
 * Last Modified: October 22, 2020
 * Source File Name: ScoreScript.cs
 
 * Program Description: Manages the score in the Game.

 * Modifications:  * Get the Text to set it to display the score.
     */

public class ScoreScript : MonoBehaviour
{
    public static int score = 0; // static score int can get called in other scripts/classes
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score = " + score.ToString(); // Set the score text to display the score.
    }
}
