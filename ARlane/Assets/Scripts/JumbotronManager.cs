using System;
using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class JumbotronManager : MonoBehaviour, IFocusable
{

    public MovieTexture video_bai;
    public MovieTexture video_cheerios;
    public MovieTexture video_coffee;
    public MovieTexture video_oatmeal;
    public MovieTexture video_oregano;
    public MovieTexture video_pasta;
    public MovieTexture video_soap;
    public MovieTexture video_toothpaste;
    public MovieTexture video_tortilla;

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
        if (videoKey == 0)
        {
            movieTexture = video_bai;
            transform.GetComponent<Renderer>().material.mainTexture = movieTexture;
        }
        else if (videoKey == 1)
        {
            movieTexture = video_cheerios;
            transform.GetComponent<Renderer>().material.mainTexture = movieTexture;
        }
        else if (videoKey == 2)
        {
            movieTexture = video_coffee;
            transform.GetComponent<Renderer>().material.mainTexture = movieTexture;
        }
        else if (videoKey == 3)
        {
            movieTexture = video_oatmeal;
            transform.GetComponent<Renderer>().material.mainTexture = movieTexture;
        }
        else if (videoKey == 4)
        {
            movieTexture = video_oregano;
            transform.GetComponent<Renderer>().material.mainTexture = movieTexture;
        }
        else if (videoKey == 5)
        {
            movieTexture = video_pasta;
            transform.GetComponent<Renderer>().material.mainTexture = movieTexture;
        }
        else if (videoKey == 6)
        {
            movieTexture = video_soap;
            transform.GetComponent<Renderer>().material.mainTexture = movieTexture;
        }
        else if (videoKey == 7)
        {
            movieTexture = video_toothpaste;
            transform.GetComponent<Renderer>().material.mainTexture = movieTexture;
        }
        else if (videoKey == 8)
        {
            movieTexture = video_tortilla;
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
