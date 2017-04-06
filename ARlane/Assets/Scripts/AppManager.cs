using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;


namespace Arlane
{
    public class AppManager : MonoBehaviour
    {

        public string API;
        public int refresh = 100;
        public GameObject store;

        public static AppManager instance = null;

        private int counter;
        private GameObject shoppingList;

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


            // Setup the store
            if( Store.instance == null )
            {
                Instantiate(store);
            }

            // Start fetching data
            fetchData();
        }

        // Use this for initialization
        void Start()
        {
            //shoppingList = GameObject.Find("ShoppingList").GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            counter++;

            if(counter % refresh == 0)
            {
                fetchData();
            }
        }

        void fetchData()
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

                for (int i = 0; i < res.results.Length; i++)
                {
                    // TODO - Update the state of the app
                }
            }
            else
            {
                Debug.Log("WWW Error: " + www.error);
            }
        }
    }
}

