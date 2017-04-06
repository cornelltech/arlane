using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace Arlane
{
    public class ListItemManager : MonoBehaviour
    {

        public string text;

        private GameObject textObj;

        // Use this for initialization
        void Start()
        {
            textObj = transform.Find("3DTextPrefab").gameObject;
            textObj.GetComponent<TextMesh>().text = text;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
