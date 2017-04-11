using System;
using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;


namespace Arlane
{

    public class BackgroundTapCatcher : MonoBehaviour, IInputClickHandler
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnInputClicked(InputEventData eventData)
        {
            Debug.Log("Clicked the background");
            AppManager.instance.SetActiveItem(null);
        }
    }


}