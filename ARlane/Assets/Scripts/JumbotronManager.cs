using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumbotronManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        playVideo();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playVideo()
    {
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
    }
}
