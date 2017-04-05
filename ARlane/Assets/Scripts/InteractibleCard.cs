using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The main product card
/// </summary>
public class InteractibleCard : MonoBehaviour {

    public Material frontCard;
    public Material frontCardActive;

    private GameObject front;

    void Start()
    {
        print("Start interactible");
        front = gameObject.transform.Find("Front").gameObject;
        print(front);
    }

    void GazeEntered()
    {
        print("GAZE ENTERED");
        front.GetComponent<Renderer>().material = frontCardActive;
    }

    void GazeExited()
    {
        print("GAZE LEFT");
        front.GetComponent<Renderer>().material = frontCard;
    }
    
}
