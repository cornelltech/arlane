﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using HoloToolkit.Unity.InputModule;
using System;


/// <summary>
/// Responsible for handling the card events
/// </summary>

namespace Arlane
{

    public class CardManager : MonoBehaviour, IInputClickHandler, IFocusable
    {

        public ProductObj obj;

        public Material frontCard;
        public Material frontCardActive;
        public int rotationSpeed = 10;

        private GameObject front;
        private GameObject back;
        private bool canRotate;
        private int rotationCount = 0;

        // Use this for initialization
        void Start()
        {
            front = gameObject.transform.Find("Front").gameObject;
            back = gameObject.transform.Find("Back").gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            if (canRotate)
            {
                RotateCard();
            }
        }




        public void OnInputClicked(InputEventData eventData)
        {
            canRotate = true;
        }

        public void OnFocusEnter()
        {
            front.GetComponent<Renderer>().material = frontCardActive;
        }

        public void OnFocusExit()
        {
            front.GetComponent<Renderer>().material = frontCard;
        }



        private void RotateCard()
        {
            transform.Rotate(new Vector3(0, 1, 0), 10, Space.Self);

            rotationCount++;
            if (180 / rotationSpeed == rotationCount)
            {
                rotationCount = 0;
                canRotate = false;
            }
        }

        public void Show()
        {

            gameObject.SetActive(true);
            
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        
        }
    }


}

