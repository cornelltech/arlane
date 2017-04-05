using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingListManager : MonoBehaviour {

    public GameObject listItem;
    public Font listItemFont;

	// Use this for initialization
	void Start () {
        print("Shopping List Started");

        // Generate the items here
        for (int i = 0; i < 5; i++)
        {
            float offset = 0.5f * i;
            Vector3 pos = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);
            Quaternion rot = transform.rotation;

            GameObject listItemObj = (GameObject) Instantiate(listItem, pos, rot);
            listItemObj.GetComponent<TextMesh>().text = "Apples";
            listItemObj.GetComponent<TextMesh>().font = listItemFont;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
