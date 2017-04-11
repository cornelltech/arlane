using System;
using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class JumbotronManager : MonoBehaviour, IFocusable
{
    public string foo;
    private MovieTexture movieTexture;
    private AudioSource audioSrc;

    // Use this for initialization
    void Start () {
        playVideo();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playVideo()
    {
        print("Play video");
        movieTexture = (MovieTexture)GetComponent<Renderer>().material.mainTexture;
        movieTexture.loop = true;
        audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = movieTexture.audioClip;
        movieTexture.Play();
        audioSrc.Play();
    }

    public void OnFocusEnter()
    {
        if (movieTexture && audioSrc)
        {
            audioSrc.mute = false;
        }
    }

    public void OnFocusExit()
    {
        if (movieTexture && audioSrc)
        {
            audioSrc.mute = true;
        }
    }
}
