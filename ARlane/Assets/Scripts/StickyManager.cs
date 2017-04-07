using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.VR.WSA.Persistence;
using UnityEngine.VR.WSA;
using System;

public class StickyManager : MonoBehaviour, IInputClickHandler
{

    public string ObjectAnchorStoreName;

    WorldAnchorStore anchorStore;

    bool Placing = false;

	// Use this for initialization
	void Start () {
        WorldAnchorStore.GetAsync(AnchorStoreReady);
	}
	
	// Update is called once per frame
	void Update () {
		if (Placing)
        {
            gameObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2;
        }
	}

    void AnchorStoreReady(WorldAnchorStore store)
    {
        anchorStore = store;
        Placing = true;

        Debug.Log("Looking for " + ObjectAnchorStoreName);
        string[] ids = anchorStore.GetAllIds();
        for (int i=0; i<ids.Length; i++)
        {
            Debug.Log(ids[i]);
            if (ids[i] == ObjectAnchorStoreName)
            {
                WorldAnchor wa = anchorStore.Load(ids[i], gameObject);
            }
            Placing = false;
            break;
        }
    }

    public void OnInputClicked(InputEventData eventData)
    {
        if (anchorStore == null)
        {
            return;
        }

        if (Placing)
        {
            WorldAnchor attachingAnchor = gameObject.AddComponent<WorldAnchor>();
            if (attachingAnchor.isLocated)
            {
                Debug.Log("Saving persisted position immediately");
                bool saved = anchorStore.Save(ObjectAnchorStoreName, attachingAnchor);
                Debug.Log("Saved: " + saved);
            }
            else
            {
                attachingAnchor.OnTrackingChanged += AttachingAnchor_OnTrackingChanged;
            }

        }
        else
        {
            WorldAnchor anchor = gameObject.GetComponent<WorldAnchor>();
            if (anchor != null)
            {
                DestroyImmediate(anchor);
            }

            string[] ids = anchorStore.GetAllIds();
            for (int i = 0; i < ids.Length; i++)
            {
                Debug.Log(ids[i]);
                if (ids[i] == ObjectAnchorStoreName)
                {
                    bool deleted = anchorStore.Delete(ids[i]);
                    Debug.Log("Deleted: " + deleted);
                    break;
                }
            }
        }

        Placing = !Placing;

    }

    private void AttachingAnchor_OnTrackingChanged(WorldAnchor self, bool located)
    {
        if (located)
        {
            Debug.Log("Saving persisted position in callbacl");
            bool saved = anchorStore.Save(ObjectAnchorStoreName, self);
            Debug.Log("saved: " + saved);
            self.OnTrackingChanged -= AttachingAnchor_OnTrackingChanged;
        }
    }
}
