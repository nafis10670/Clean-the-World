using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //public float speed = 5f;
    public float currentSpeed = -1f;
    float targetSpeed = -30f;
    
    public static bool Ispaused=false;
    public GameObject PauseMenuUi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed > targetSpeed)
        {
            currentSpeed -= Time.deltaTime;
        }
        transform.position = transform.position + new Vector3( currentSpeed* Time.deltaTime*.25f,  0, 0);
        //Debug.Log(transform.position);
    }
    
     private void OnTriggerEnter(Collider other)
     {
         if (other.tag == "Collectible")
        {
            Pause();
        }
    }
     void Pause()
     {
         PauseMenuUi.SetActive(true);
         Time.timeScale = 0f;
         Ispaused = true;
     }
     
     public void Resume()
     {
         PauseMenuUi.SetActive(false);
         SceneManager.LoadScene(0);
         Time.timeScale = 1f;
         Ispaused = false;
         
     }

}
