using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using HoloToolkit.Unity.InputModule;
using System;

/// <summary>
/// The Interactible class flags a Game Object as being "Interactible".
/// Determines what happens when an Interactible is being gazed at.
/// </summary>
public class Interactible : MonoBehaviour, IInputClickHandler
{
    public Material frontCard;
    public Material frontCardActive;
    public int rotationSpeed = 10;

    private GameObject front;
    private GameObject back;
    private bool canRotate;
    private int rotationCount = 0;
    
    void Start()
    {
        front = gameObject.transform.Find("Front").gameObject;
    }

    void Update()
    {
        if(canRotate)
        {
            RotateCard();
        }
    }

    void GazeEntered()
    {
        front.GetComponent<Renderer>().material = frontCardActive;
    }
    void GazeExited()
    {
        front.GetComponent<Renderer>().material = frontCard;
    }
    
    public void OnInputClicked(InputEventData eventData)
    {
        canRotate = true;
    }

    void RotateCard()
    {
        transform.Rotate(new Vector3(0, 1, 0), 10, Space.Self);
  
        rotationCount++;
        if(  180 / rotationSpeed == rotationCount )
        {
            rotationCount = 0;
            canRotate = false;
        }

    }
}
