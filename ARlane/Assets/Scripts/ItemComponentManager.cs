using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using HoloToolkit.Unity.InputModule;
using System;


/// <summary>
/// Responsible for handling the item component events
/// </summary>
/// 
namespace Arlane
{

    public class ItemComponentManager : MonoBehaviour, IInputClickHandler, IFocusable
    {

        public ProductObj obj;

        private GameObject card;
        private CardManager cardManager;

        private GameObject item;
        private ItemManager itemManager;

        // Use this for initialization
        void Start()
        {
            item = transform.Find("Item").gameObject;
            itemManager = item.GetComponent<ItemManager>();
            itemManager.obj = obj;

            card = transform.Find("Card").gameObject;
            cardManager = card.GetComponent<CardManager>();
            cardManager.obj = obj;
            
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

        }

        public void OnFocusExit()
        {

        }

        public void ShowCard()
        {
            cardManager.Show();
        }

        public void HideCard()
        {
            cardManager.Hide();
        }

        public void ShowItem()
        {
            itemManager.Show();
        }
        public void HideItem()
        {
            itemManager.Hide();
        }
    }


}
