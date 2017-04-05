using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Interactible class flags a Game Object as being "Interactible".
/// Determines what happens when an Interactible is being gazed at.
/// </summary>
public class Interactible : MonoBehaviour
{
    public Material frontCard;
    public Material frontCardActive;

    private GameObject front;
    
    void Start()
    {
        print("START START");
        front = gameObject.transform.Find("Front").gameObject;
    }

    void GazeEntered()
    {
        print("I am gazing");
        front.GetComponent<Renderer>().material = frontCardActive;

    }
    void GazeExited()
    {
        print("I am not gazing");
        front.GetComponent<Renderer>().material = frontCard;
    }

    void OnSelect()
    {
        print("I am selecting");

    }
}
