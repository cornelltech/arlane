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

        private int counter;

        // Use this for initialization
        void Start()
        {
            print("App Started");
            fetchData();

        }

        // Update is called once per frame
        void Update()
        {
            counter++;

            if(counter % refresh == 0)
            {
                //print("Tick " + counter.ToString());
                fetchData();
            }
        }

        void fetchData()
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(API + "/ping");
                ProductList res = ProductList.CreateFromJSON(json);

                for (int i = 0; i < res.results.Length; i++)
                {
                    // print(res.results[i].product);

                    // TODO - Update the state of the app

                }
            }
        }
    }
}

