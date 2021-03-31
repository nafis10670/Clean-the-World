using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]
    public bool gameStarted;
    [HideInInspector]
    public bool canAppear;
    public static SelectedObjectType selectedObjectType = SelectedObjectType.None;
    
    void Awake()
    {
        instance = this;
    }
    
    
    
    public void Start()
    {
        // instance = this;
        gameStarted = false;
        canAppear = false;

    }
    /*private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }*/

    public enum SelectedObjectType
    {
        None,
        Blue,
        Red
    }
}
