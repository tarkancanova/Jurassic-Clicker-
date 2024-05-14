using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledCustomers;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledCustomers = new List<GameObject>();
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            pooledCustomers.Add(go);
            go.SetActive(false);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (!pooledCustomers[i].activeInHierarchy)
            {
                return pooledCustomers[i];
            }
        }
        return null;
    }
}
