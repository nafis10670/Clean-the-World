using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ObstacleController : MonoBehaviour
{
    public List<Collectible> trashes;
    private DragAndDropController dragController;

    private void Awake()
    {
        dragController = GetComponent<DragAndDropController>();
    }
    //public Image collectibleImage;

    // Start is called before the first frame update
    void OnEnable()
    {
        int r = Random.Range(0, trashes.Count);

        //trashes[r].transform.position = this.gameObject.transform.position;
        trashes[r].gameObject.SetActive(true);
        dragController.selectedCollectibleSprite = trashes[r].collectible;
        dragController.selectedObjectType = trashes[r].selectedObjectType;
        //Debug.Log(r);
    }

    private void OnDisable()
    {
        DeactiveAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeactiveAll(){
        for (int i = 0; i < trashes.Count; i++)
        {
            trashes[i].gameObject.SetActive(false);
        }
    }
}
