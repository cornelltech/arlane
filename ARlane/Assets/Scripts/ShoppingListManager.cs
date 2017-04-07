﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arlane
{
    public class ShoppingListManager : MonoBehaviour
    {
        public GameObject listItemPrefab;
        public Font listItemFont;

        private List<GameObject> children = new List<GameObject>();

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void CleanupChildren()
        {
            foreach (GameObject child in children)
            {
                GameObject.Destroy(child);
            }
        }

        public void UpdateText(ProductList data)
        {
            Debug.Log("==================");
            Debug.Log("upadteText()");

            // Cleanup first
            if( children.Count > 0 )
            {
                CleanupChildren();
            }

            
            // Populate list
            for ( int i=0; i < data.results.Length; i++ )
            {
                //Debug.Log(data.results[i].product);

                float offset = 0.1f - (i * 0.05f);
                Vector3 pos = new Vector3(transform.localPosition.x, transform.localPosition.y + offset, transform.localPosition.z);
                Quaternion rot = transform.rotation;

                GameObject listItemObj = Instantiate(listItemPrefab, pos, rot);
                listItemObj.GetComponent<TextMesh>().text = data.results[i].product;
                listItemObj.GetComponent<TextMesh>().offsetZ = -5;
                //listItemObj.GetComponent<TextMesh>().font = listItemFont;
                listItemObj.transform.parent = gameObject.transform;
                
                children.Add(listItemObj);

                Debug.Log("Product: " + data.results[i].product + " Selected: " + data.results[i].selected);
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
