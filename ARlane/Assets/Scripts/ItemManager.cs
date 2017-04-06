using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using HoloToolkit.Unity.InputModule;
using System;

namespace Arlane
{

    /// <summary>
    /// Responsible for handling the item events
    /// </summary>
    public class ItemManager : MonoBehaviour, IInputClickHandler, IFocusable
    {

        private GameObject scanner;

        // Use this for initialization
        void Start()
        {
            scanner = transform.Find("Scanner").gameObject;
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void OnInputClicked(InputEventData eventData)
        {

        }

        public void OnFocusEnter()
        {
            scanner.GetComponent<ScannerManager>().Show();
            scanner.GetComponent<ScannerManager>().startTime = Time.time;
            scanner.GetComponent<ScannerManager>().performScan = true;
        }

        public void OnFocusExit()
        {

        }

    }


}
