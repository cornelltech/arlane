using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arlane
{
    public class ShoppingListManager : MonoBehaviour
    {

        public ProductObj[] list;
        public GameObject listItemPrefab;
        public Font listItemFont;

        private int listLength;

        // Use this for initialization
        void Start()
        {
            print("Shopping List Started");

            listLength = list.Length; // not the smartest but will do for now.

            setupText();

        }

        // Update is called once per frame
        void Update()
        {

        }

        void setupText()
        {
            for ( int i=0; i < list.Length; i++ )
            {
                float offset = 0.1f - (i * 0.05f);
                Vector3 pos = new Vector3(transform.localPosition.x, transform.localPosition.y + offset, transform.localPosition.z);
                Quaternion rot = transform.rotation;

                print("here is the product");
                

                GameObject listItemObj = (GameObject)Instantiate(listItemPrefab, pos, rot);
                listItemObj.GetComponent<TextMesh>().text = list[i].product;
                listItemObj.GetComponent<TextMesh>().offsetZ = -5;
                //listItemObj.GetComponent<TextMesh>().font = listItemFont;
                listItemObj.transform.parent = gameObject.transform;
            }
        }

        public void Show()
        {
            print("Show shopping list");
            gameObject.SetActive(true);
        }
        public void Hide()
        {
            print("Hide shopping list");
            gameObject.SetActive(false);
        }
    }

}
