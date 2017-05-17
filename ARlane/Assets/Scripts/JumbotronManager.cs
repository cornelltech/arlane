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
        }
        else if (videoKey == 1)
        {
            movieTexture = video_cheerios;
        }
        else if (videoKey == 2)
        {
            movieTexture = video_coffee;
        }
        else if (videoKey == 3)
        {
            movieTexture = video_oatmeal;
        }
        else if (videoKey == 4)
        {
            movieTexture = video_oregano;
        }
        else if (videoKey == 5)
        {
            movieTexture = video_pasta;
        }
        else if (videoKey == 6)
        {
            movieTexture = video_soap;
        }
        else if (videoKey == 7)
        {
            movieTexture = video_toothpaste;
        }
        else if (videoKey == 8)
        {
            movieTexture = video_tortilla;
        }
        else
        {
            Debug.Log("Defaulting to CT video");
            movieTexture = (MovieTexture)GetComponent<Renderer>().material.mainTexture;
        }
        Debug.Log(movieTexture);
        //DestroyImmediate(transform.GetComponent<Renderer>().material.mainTexture, true); // free memory


        if( movieTexture)
        {
            transform.GetComponent<Renderer>().material.mainTexture = movieTexture;

            movieTexture.loop = true;

            audioSrc.clip = movieTexture.audioClip;
            audioSrc.mute = true;

            movieTexture.Play();
            audioSrc.Play();
        }
       
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
