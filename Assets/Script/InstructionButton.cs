using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Matthew Makepeace
 * Student Number: 101179668
 * Last Modified: September 26, 2020
 * Source File Name: InstructionButton.cs
 
 * Program Description: Script for the Instruction Button Behaviour to take the
   user to the Instruction Scene
 
 * Modifications: NONE
     */

public class InstructionButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Event handler for the OnInstructionButtonPressed event
    public void OnInstructionButtonPressed()
    {
        Debug.Log("Instruction Button Pressed!");
        SceneManager.LoadScene("Instruction");
    }
}
