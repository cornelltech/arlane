using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using UnityEngine;


namespace Arlane
{
    public class AppManager : MonoBehaviour
    {

        public string API;
        public int refresh = 100;
        public bool DEBUG = true    ;

        private int counter;
        private ProductObj focusedItem;
        private ProductList data;
        private IEnumerator coroutine;
        private GameObject jumbotron;
        private GameObject shoppingList;
        private List<GameObject> items;


        public static AppManager instance = null;

        void Awake()
        {
            if ( instance == null )
            {
                instance = this;
            }else if(instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        // Use this for initialization
        void Start()
        {
            // Start fetching data every 1s
            InvokeRepeating("FetchData", 0.0f, 1.0f);

            // Find and hide the shopping list
            shoppingList = GameObject.Find("ShoppingList");
            GameObject.Find("ShoppingList").GetComponent<ShoppingListManager>().Hide();

            // Get the list of items
            items = new List<GameObject>(GameObject.FindGameObjectsWithTag("ItemComponent"));

            // Hide the items by default
            HideItems();    

        }

        // Update is called once per frame
        void Update()
        {
            
        }


        private void FetchData()
        {
            Debug.Log("Fetch Data");
            WWW www = new WWW(API + "/ping");
            
            coroutine = WaitForRequest(www);
            StartCoroutine(coroutine);
        }

        private IEnumerator WaitForRequest(WWW www)
        {
            Debug.Log("Coroutine");
            yield return www;

            // check for errors
            if (www.error == null)
            {
                //Debug.Log("Fetched Data");
                string json = www.text;
                //Debug.Log(json);
                ProductList res = ProductList.CreateFromJSON(json);

                ProductObj[] selectedItems = res.results.Where(x => x.selected).ToArray();
                ProductList selectedProductList = new ProductList();
                selectedProductList.count = selectedItems.Length;
                selectedProductList.results = selectedItems;

                data = selectedProductList;
                // update the list
                shoppingList.GetComponent<ShoppingListManager>().UpdateText(selectedProductList);
            }
            else
            {
                Debug.Log("WWW Error: " + www.error);
            }
        }

        public void SetActiveItem(ProductObj obj)
        {
            focusedItem = obj;   
        }

        public void ShowItems()
        {
            foreach (var obj in items)
            {
                obj.GetComponent<ItemComponentManager>().ShowItem();
            }
        }
        public void HideItems()
        {
            foreach (var obj in items)
            {
                
                obj.GetComponent<ItemComponentManager>().HideItem();
                
            }
        }

        public void HideUnfocusedCards()
        {
            foreach (var item in items)
            {

                if (item.GetComponent<ItemComponentManager>().obj.id != focusedItem.id)
                {
                    item.GetComponent<ItemComponentManager>().HideCard();
                }
            }
        }

        public GameObject GetFocusedItemComponent()
        {
            foreach (var item in items)
            {
                if( item.GetComponent<ItemComponentManager>().obj.id == focusedItem.id)
                {
                    return item;
                }
            }

            return null;
        }

        public void DismissItem()
        {
            foreach (var item in items)
            {
                item.GetComponent<ItemComponentManager>().Dismiss();
            }
            focusedItem = null;
        }

        public void CheckItem()
        {
            foreach (var item in data.results)
            {
                if( item.id == focusedItem.id )
                {
                    item.selected = false;
                }
            }
            DismissItem();
        }
        
        public bool isActiveObj(ProductObj obj)
        {
            if(focusedItem != null)
            {
                return focusedItem.id == obj.id;
            }
            else
            {
                return false;
            }
            
        }
        public bool hasActiveObj()
        {
            return focusedItem != null;
        }

        public void EasterEgg()
        {
            Debug.Log("Easter Egg");
        }
    }
}

