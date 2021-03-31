using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenarator : MonoBehaviour
{
    public Vector3 lastPosition;
    public float pathOffset = -10f;
    public ObjectPooling objectPooler;
    [HideInInspector]
    public int pathCount;




    void Update()
    {
        //CreateNewPath();
        if (GameManager.instance.canAppear)
        {
            CreateNewPath();
        }
    }


    public void CreateNewPath()
    {
        GameObject newPlatform = objectPooler.GetPooledObject();
        //newPlatform.transform.position = new Vector3(lastPosition.x+ pathOffset, lastPosition.y, lastPosition.z );
        newPlatform.transform.localPosition = new Vector3(lastPosition.x+ pathOffset, lastPosition.y, lastPosition.z );

        newPlatform.SetActive(true);

        //newPlatform.GetComponent<DisablePlane>().SetCoinsBack();

        lastPosition = newPlatform.transform.position;
        GameManager.instance.canAppear = false;
        pathCount++;
        
        //if (pathCount % 1 == 0) 
        //{
        //    newPlatform.transform.Find("trash").gameObject.SetActive(true);
        //}
    }
}
