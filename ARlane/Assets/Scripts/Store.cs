using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arlane
{
    public class Store : MonoBehaviour
    {
        public static Store instance = null;
        public ProductList data { get; set; }

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }
    }
}
