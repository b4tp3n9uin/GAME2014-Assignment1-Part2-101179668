using UnityEngine.Audio;
using UnityEngine;

/*
 * Author: Matthew Makepeace
 * Student Number: 101179668
 * Last Modified: October 22, 2020
 * Source File Name: Sound.cs
 
 * Program Description: Sound Class to makes sure the sounds can be called and edited through the SoundManager in the inspector. 

 * Modifications:  * Set the variables for sounds which are the string names for the sounds, Clip, Volume, Pitch and Audio Source.
     */

[System.Serializable]
public class Sound
{
    public string name; // name of the sound

    public AudioClip clip; // Audio Clip for the sound

    [Range(0.0f, 1.0f)] // Range for the volume
    public float volume; // sound's volume.

    [Range(0.1f, 3.0f)] // Range for the pitch
    public float pitch; // sound's pitch.

    [HideInInspector]
    public AudioSource source; // Audio Source object for the sounds.
}
