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
            // Start fetching data
            fetchData();

            // Find and hide the shopping list
            shoppingList = GameObject.Find("ShoppingList");
            GameObject.Find("ShoppingList").GetComponent<ShoppingListManager>().Hide();

            // Get the list of items
            items = new List<GameObject>(GameObject.FindGameObjectsWithTag("ItemComponent"));

            foreach (var obj in items)
            {
                if (DEBUG)
                {
                    obj.GetComponent<ItemComponentManager>().ShowItem();
                    obj.GetComponent<ItemComponentManager>().ShowCard();
                }
                else
                {
                    obj.GetComponent<ItemComponentManager>().HideItem();
                    obj.GetComponent<ItemComponentManager>().HideCard();
                }
            }
            


        }

        // Update is called once per frame
        void Update()
        {
            counter++;
            
            // Poll server for data
            // TODO - this should be done as a coroutine
            if(counter % refresh == 0)
            {
                fetchData();
            }
        }


        private void fetchData()
        {
            WWW www = new WWW(API + "/ping");
            StartCoroutine(WaitForRequest(www));
        }

        private IEnumerator WaitForRequest(WWW www)
        {

            yield return www;

            // check for errors
            if (www.error == null)
            {
                var json = www.text;
                ProductList res = ProductList.CreateFromJSON(json);

                var selectedItems = res.results.Where(x => x.selected).ToArray();
                ProductList selectedProductList = new ProductList();
                selectedProductList.count = selectedItems.Length;
                selectedProductList.results = selectedItems;

                data = selectedProductList;
                // update the list
                shoppingList.GetComponent<ShoppingListManager>().updateText(data);
            }
            else
            {
                Debug.Log("WWW Error: " + www.error);
            }
        }
    }
}

