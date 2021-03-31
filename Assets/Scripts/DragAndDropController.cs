using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static GameManager;

public class DragAndDropController : MonoBehaviour
{
    public Image BottleImage;
    public Image TrashCanImageBlue;
    public Image TrashCanImageRed;
    public Sprite selectedCollectibleSprite;
    public SelectedObjectType selectedObjectType;

    public Canvas canvas;
    //public CanvasGroup canvasGroup;

    public GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    public EventSystem m_EventSystem;
    
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                print("Clicked on UI");
            }
        }
    }
    
    private void OnMouseDrag()
    {
        
        if (gameObject.CompareTag("Collectible"))
        {
            BottleImage.rectTransform.anchoredPosition = Input.mousePosition;
            BottleImage.sprite = selectedCollectibleSprite;
            GameManager.selectedObjectType = selectedObjectType;
            BottleImage.gameObject.SetActive(true);
            //print("Dragging");
        }
    }

    IEnumerator OnMouseUp()
    {
        //print("OnMouseUp");
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = Input.mousePosition;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        m_Raycaster.Raycast(m_PointerEventData, results);

        //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
        foreach (RaycastResult result in results)
        {
            if (GameManager.selectedObjectType == SelectedObjectType.Blue)
            {
                if (result.gameObject.CompareTag("DroppableBlue"))
                {
                    print("Released Over Trash BLUE");
                    BottleImage.rectTransform.anchoredPosition = TrashCanImageBlue.rectTransform.anchoredPosition;
                    yield return new WaitForSeconds(0.5f);
                    this.gameObject.SetActive(false);
                    //BottleImage.rectTransform.anchoredPosition = TrashCanImage.rectTransform.anchoredPosition;
                    //StartCoroutine(nameof(WaitAfterCollection));
                    //BottleImage.rectTransform.anchoredPosition = new Vector2(0, 0);
                }
            }

            if (GameManager.selectedObjectType == SelectedObjectType.Red)
            {
                if (result.gameObject.CompareTag("DroppableRed"))
                {
                    print("Released Over Trash RED");
                    BottleImage.rectTransform.anchoredPosition = TrashCanImageRed.rectTransform.anchoredPosition;
                    yield return new WaitForSeconds(0.5f);
                    this.gameObject.SetActive(false);
                    //BottleImage.rectTransform.anchoredPosition = TrashCanImage.rectTransform.anchoredPosition;
                    //StartCoroutine(nameof(WaitAfterCollection));
                    //BottleImage.rectTransform.anchoredPosition = new Vector2(0, 0);
                }
            }

        }
        BottleImage.rectTransform.anchoredPosition = new Vector2(0, 0);
        BottleImage.gameObject.SetActive(false);
        GameManager.selectedObjectType = SelectedObjectType.None;
        GameManager.selectedObjectType = SelectedObjectType.None;
    }
}
