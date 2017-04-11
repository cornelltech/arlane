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

        public ProductObj obj;
        
        private GameObject scanner;
        private ScannerManager scannerManager;

        // Use this for initialization
        void Start()
        {
            scanner = transform.Find("Scanner").gameObject;
            scannerManager = scanner.GetComponent<ScannerManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void OnInputClicked(InputEventData eventData)
        {
            AppManager.instance.SetActiveItem(obj);
            StartScan();
        }

        public void OnFocusEnter()
        {
            // transform.parent.GetComponent<ItemComponentManager>().setFocused(true);
        }

        public void OnFocusExit()
        {

        }

        public void StartScan()
        {
            scannerManager.Show();
            scannerManager.startTime = Time.time;
            scannerManager.StartScan();
        }

        public void Show()
        {
            //gameObject.SetActive(true);
            transform.GetComponent<Renderer>().enabled = true;
        }

        public void Hide()
        {
            //gameObject.SetActive(false);
            transform.GetComponent<Renderer>().enabled = false;
        }

    }


}
