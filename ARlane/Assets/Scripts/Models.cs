using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Arlane
{
    [System.Serializable]

    public class ProductObj

    {

        public int id;

        public string product;

        public bool selected;



        public static ProductObj CreateFromJSON(string jsonString)

        {

            return JsonUtility.FromJson<ProductObj>(jsonString);

        }

    }

    [System.Serializable]

    public class ProductList

    {

        public int count;

        public ProductObj[] results;



        public static ProductList CreateFromJSON(string jsonString)

        {

            return JsonUtility.FromJson<ProductList>(jsonString);

        }

    }



    public class State

    {

        public ProductList data;

    }

}

