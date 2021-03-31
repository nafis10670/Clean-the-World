using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject[] pooledObject;

    public int pooledAmount;
    
    List<GameObject> pooledObjects;

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        AddObjects();
    }

    void AddObjects()
    {
        for (int i = 0; i < pooledAmount; i++)
        {
            //int r = Random.Range(0, pooledObject.Length);
            GameObject obj = (GameObject) Instantiate(pooledObject[i]);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            //Debug.Log("object pooling");
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                //Debug.Log("get");
                //Debug.Log();
                //pooledObjects[i].transform.GetChild(0);
                pooledObjects[i].transform.Find("trash").gameObject.SetActive(true);
                //print(pooledObjects[i].transform.Find("trash").gameObject.tag.ToString());
                return pooledObjects[i];
            }
        }

        int r = Random.Range(0, pooledObject.Length);
        //Debug.Log("r");
        GameObject obj = (GameObject)Instantiate(pooledObject[r],transform);

        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}


