using System;
using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class JumbotronManager : MonoBehaviour, IFocusable
{

    public MovieTexture video0;

    private MovieTexture movieTexture;
    private AudioSource audioSrc;

    // Use this for initialization
    void Start () {
        audioSrc = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playVideo(int videoKey)
    {

        Debug.Log("===========================");

        Debug.Log("playVideo: ");
        Debug.Log(videoKey);

        Debug.Log("===========================");

        if (videoKey == 0)
        {
            Debug.Log("Setting movie texture to 0");
            movieTexture = video0;
            transform.GetComponent<Renderer>().material.mainTexture = movieTexture;
        }
        else
        {
            Debug.Log("Defaulting to CT video");
            movieTexture = (MovieTexture)GetComponent<Renderer>().material.mainTexture;
        }
        Debug.Log(movieTexture);

        //movieTexture = (MovieTexture)GetComponent<Renderer>().material.mainTexture;
        
        audioSrc.clip = movieTexture.audioClip;


        movieTexture.loop = true;

        //movieTexture.Stop();

        audioSrc.mute = false;

        movieTexture.Play();
        audioSrc.Play();
    }

    public void OnFocusEnter()
    {
        Debug.Log("OnFocusEnter");
        if (movieTexture && audioSrc)
        {
            Debug.Log("Unmute it");
            audioSrc.mute = false;
        }
    }

    public void OnFocusExit()
    {
        Debug.Log("OnFocusExit");
        if (movieTexture && audioSrc)
        {
            Debug.Log("Muite It");
            audioSrc.mute = true;
        }
    }
}
