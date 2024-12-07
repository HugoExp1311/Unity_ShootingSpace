using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPool : MonoBehaviour
{
    public static objectPool current;
    public bool WillGrow; public int poolNum = 10;

    private Dictionary<GameObject, List<GameObject>> poolDictionary;

    private void Awake()
    {
        current = this;
        poolDictionary = new Dictionary<GameObject, List<GameObject>>();
    }

    public void InitializePool(GameObject prefab, int poolNum)
    {
        if (!poolDictionary.ContainsKey(prefab))
        {
            poolDictionary[prefab] = new List<GameObject>();
            for (int i = 0; i < poolNum; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                poolDictionary[prefab].Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(GameObject prefab)
    {
        if (poolDictionary.ContainsKey(prefab))
        {
            List<GameObject> poolList = poolDictionary[prefab];
            for (int i = 0; i < poolList.Count; i++)
            {
                if (!poolList[i].activeInHierarchy)
                {
                    return poolList[i];
                }
            }

            if (WillGrow)
            {
                GameObject obj = Instantiate(prefab);
                poolList.Add(obj);
                return obj;
            }
        }
        else
        {
            // If the pool for this prefab doesn't exist, initialize it
            InitializePool(prefab,poolNum); // Initialize with a default pool size
            return GetPooledObject(prefab);
        }

        return null;
    }
}
