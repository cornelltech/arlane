﻿using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;


public class AppManager : MonoBehaviour {

    public string API;

	// Use this for initialization
	void Start () {

        print("App Started");

        // using (WebClient wc = new WebClient())
        // {
        //     var json = wc.DownloadString(API + "/ping");
        //     print("Got it");
        //     print(json);
        // }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
