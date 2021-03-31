using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool Ispaused=false;
    public GameObject PauseMenuUi;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Ispaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        Ispaused = false;
            
    }
    void Pause()
    {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        Ispaused = true;
    }
}
