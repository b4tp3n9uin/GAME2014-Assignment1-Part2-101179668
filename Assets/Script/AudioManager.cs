using UnityEngine.Audio;
using UnityEngine;
using System;

/*
 * Author: Matthew Makepeace
 * Student Number: 101179668
 * Last Modified: October 22, 2020
 * Source File Name: AudioManager.cs
 
 * Program Description: Creates the sound array and manages the Audio in the game.

 * Modifications:  * Create an array of sounds.
                   * Create a play function so the array can find the sound name, and play it.
                   
     */

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; // create an array of sounds.

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds) // loop through the list of sounds in the array.
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name) // Plays the sound you're looking for.
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
