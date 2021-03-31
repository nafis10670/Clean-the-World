using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRoad : MonoBehaviour
{
    public float sec = 2f;
    //public GameObject road;
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            //Debug.Log("collision");
            StartCoroutine(LateCall());
            this.transform.parent.gameObject.SetActive(false);
            GameManager.instance.canAppear = true;
        }
    }
    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(sec);
        gameObject.SetActive(false);
    }
}
