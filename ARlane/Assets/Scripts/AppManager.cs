using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;


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

public class AppManager : MonoBehaviour {

    public string API;

	// Use this for initialization
	void Start () {

        print("App Started");

        using (WebClient wc = new WebClient())
        {
            var json = wc.DownloadString(API + "/ping");
            ProductList res = ProductList.CreateFromJSON(json);

            for (int i = 0; i < res.results.Length; i++)
            {
                print(res.results[i].product);
            }
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
