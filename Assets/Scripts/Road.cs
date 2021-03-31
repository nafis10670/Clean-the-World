using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public Vector3 lastPos;
    public float offset =15.0f;

    public ObjectPooling objectPool;

    private int roadCount = 0;
    
    void Update()
    {
        if (GameManager.instance.canAppear)
        {
            CreateNewRoadPart();
            Debug.Log("Create new road");
        }
    }

    public void CreateNewRoadPart()
    {
        Debug.Log("Create new road part");
        
        GameObject newRoad = objectPool.GetPooledObject();

        newRoad.transform.position = new Vector3(lastPos.x , lastPos.y, lastPos.z + offset);
        
        newRoad.SetActive(true);
        
        lastPos=newRoad.transform.position;
        GameManager.instance.canAppear = false;
        roadCount++;
    }
}
