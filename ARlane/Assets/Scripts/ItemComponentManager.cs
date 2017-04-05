using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using HoloToolkit.Unity.InputModule;
using System;


/// <summary>
/// Responsible for handling the item component events
/// </summary>
public class ItemComponentManager : MonoBehaviour, IInputClickHandler, IFocusable
{

    private GameObject card;
    private CardManager cardManager;

	// Use this for initialization
	void Start () {
        card = gameObject.transform.Find("Card").gameObject;
        cardManager = card.GetComponent<CardManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnInputClicked(InputEventData eventData)
    {

    }

    public void OnFocusEnter()
    {
        cardManager.isVisible = true;
    }

    public void OnFocusExit()
    {
        //cardManager.isVisible = false;
    }
}
