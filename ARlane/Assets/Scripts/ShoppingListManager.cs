using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arlane
{
    public class ShoppingListManager : MonoBehaviour
    {
        public GameObject listItemPrefab;
        public Font listItemFont;

        private ProductList data;
        private List<GameObject> children;

        // Use this for initialization
        void Start()
        {
            print("Shopping List Started");
            data = Store.instance.data;
            children = new List<GameObject>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Store.instance.data != null && data == null)
            {
                data = Store.instance.data;
                updateText();
            } else if (Store.instance.data != null && data.count != Store.instance.data.count)
            {
                data = Store.instance.data;
                updateText();
            } else
            {
                // pass
            }
        } 

        void updateText()
        {

            // Cleanup first
            if( children.Count > 0 )
            {
                CleanupChildren();
            }
            

            // Populate list
            for ( int i=0; i < data.results.Length; i++ )
            {
                float offset = 0.1f - (i * 0.05f);
                Vector3 pos = new Vector3(transform.localPosition.x, transform.localPosition.y + offset, transform.localPosition.z);
                Quaternion rot = transform.rotation;

                GameObject listItemObj = Instantiate(listItemPrefab, pos, rot);
                listItemObj.GetComponent<TextMesh>().text = data.results[i].product;
                listItemObj.GetComponent<TextMesh>().offsetZ = -5;
                //listItemObj.GetComponent<TextMesh>().font = listItemFont;
                listItemObj.transform.parent = gameObject.transform;

                children.Add(listItemObj);
            }
        }

        void CleanupChildren()
        {
            foreach (GameObject child in children)
            {
                GameObject.Destroy(child);
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
