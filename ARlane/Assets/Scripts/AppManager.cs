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
        private IEnumerator coroutine;

        private ProductList data; // the selected product list on the shopping list
        private ProductObj focusedItem;

        private GameObject jumbotron;
        private JumbotronManager jumbotronManager;

        private GameObject shoppingList;
        private ShoppingListManager shoppingListManager;

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
            // Find and hide the shopping list
            shoppingList = GameObject.Find("ShoppingList");
            if (shoppingList)
            {
                shoppingListManager = shoppingList.GetComponent<ShoppingListManager>();
            }
            // Hide the shopping list on startup
            HideShoppingList();
            //ShowShoppingList();

            // Get the list of items
            items = new List<GameObject>(GameObject.FindGameObjectsWithTag("ItemComponent"));

            // Hide the items by default
            // HideItems();

            // Find the jumbotron
            jumbotronManager = GameObject.Find("Jumbotron").GetComponent<JumbotronManager>();
            jumbotronManager.playVideo(-1);

            // Start fetching data every 1s
            InvokeRepeating("FetchData", 0.0f, 1.0f);

        }

        // Update is called once per frame
        void Update()
        {
            
        }


        private void FetchData()
        {
            //Debug.Log("Fetch Data");
            WWW www = new WWW(API + "/ping");
            
            coroutine = WaitForRequest(www);
            StartCoroutine(coroutine);
        }

        private IEnumerator WaitForRequest(WWW www)
        {
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
                shoppingListManager.UpdateText(selectedProductList);
            }
            else
            {
                Debug.Log("WWW Error: " + www.error);
            }

            www.Dispose();
        }

        public void SetActiveItem(ProductObj obj)
        {
            focusedItem = obj;
            jumbotronManager.playVideo(0);
            HideUnfocusedCards();
        }

        public void ShowItems()
        {
            items = new List<GameObject>(GameObject.FindGameObjectsWithTag("ItemComponent"));
            foreach (var obj in items)
            {
                obj.GetComponent<ItemComponentManager>().ShowItem();
            }
        }

        public void HideItems()
        {
            items = new List<GameObject>(GameObject.FindGameObjectsWithTag("ItemComponent"));
            foreach (var obj in items)
            {
                obj.GetComponent<ItemComponentManager>().HideItem();   
            }
        }

        public void HideUnfocusedCards()
        {
            items = new List<GameObject>(GameObject.FindGameObjectsWithTag("ItemComponent"));


            foreach (var item in items)
            {
                if (focusedItem == null)
                {
                    item.GetComponent<ItemComponentManager>().HideCard();
                }
                else if (focusedItem != null && item.GetComponent<ItemComponentManager>().obj.id != focusedItem.id)
                {
                    item.GetComponent<ItemComponentManager>().HideCard();
                }
                else
                {
                    continue;
                }
            }
        }

        public GameObject GetFocusedItemComponent()
        {
            items = new List<GameObject>(GameObject.FindGameObjectsWithTag("ItemComponent"));
            foreach (var item in items)
            {
                if( focusedItem != null && item.GetComponent<ItemComponentManager>().obj.id == focusedItem.id)
                {
                    return item;
                }
            }

            return null;
        }

        public void DismissItem()
        {
            items = new List<GameObject>(GameObject.FindGameObjectsWithTag("ItemComponent"));
            foreach (var item in items)
            {
                item.GetComponent<ItemComponentManager>().HideCard();
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

        public void ShowShoppingList()
        {           
            //Debug.Log("ShowShoppingList");
            FetchData();
            shoppingListManager.Show();   
        }

        public void HideShoppingList()
        {
            //Debug.Log("HideShoppingList");
            FetchData();
            shoppingListManager.Hide();
        }

        public void VoiceTest()
        {
            Debug.Log("Voice Workds");
        }
    }
}

