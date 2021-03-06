﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arlane
{
    public class ScannerManager : MonoBehaviour
    {

        public float offsetY = 2f;
        public float speed = 1.5f;
        public float startTime;

        public bool performScan = false;

        private Vector3 start;
        private Vector3 destination;
        private float journeyLength;

        void Awake()
        {
            gameObject.SetActive(false);
        }

        // Use this for initialization
        void Start()
        {
            startTime = Time.time;

            start = transform.localPosition;
            destination = new Vector3(start.x, start.y + offsetY, start.z);
            journeyLength = Vector3.Distance(start, destination);
        }

        // Update is called once per frame
        void Update()
        {
            if (performScan)
            {
                updatePosition();
            }
        }

        public void StartScan()
        {
            performScan = true;
            transform.parent.parent.GetComponent<ItemComponentManager>().setScanning(true);
        }

        void updatePosition()
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.localPosition = Vector3.Lerp(start, destination, fracJourney);

            if (fracJourney >= 1.0)
            {
                performScan = false;
                transform.localPosition = start;
                transform.parent.parent.GetComponent <ItemComponentManager> ().setScanning(false);
                Hide();
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
