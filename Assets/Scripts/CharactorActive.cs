using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorActive : MonoBehaviour
{

    public GameObject Charactor;
    
    void Start()
    {
        Charactor.GetComponent<Movement>().enabled = true;
    }
}
