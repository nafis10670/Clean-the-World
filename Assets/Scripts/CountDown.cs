﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public GameObject Countdown;
    public GameObject CharactorControl;
    public Animator CharAnimator;

    public static CountDown instance;
    void Start()
    {
        StartCoroutine(CountStart());
    }

    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);
        Countdown.GetComponent<Text>().text = "3";
        //GetReady.Play();
        Countdown.SetActive(true);
        yield return new WaitForSeconds(1);
        Countdown.SetActive(false);
        Countdown.GetComponent<Text>().text = "2";
        //GetReady.Play();
        Countdown.SetActive(true);
        yield return new WaitForSeconds(1);

        Countdown.SetActive(false);
        Countdown.GetComponent<Text>().text = "1";
        //GetReady.Play();
        Countdown.SetActive(true);
        yield return new WaitForSeconds(1);
        Countdown.SetActive(false);

        Countdown.SetActive(false);
        Countdown.GetComponent<Text>().text = "GO!";
        //GetReady.Play();
        Countdown.SetActive(true);
        yield return new WaitForSeconds(1);
        Countdown.SetActive(false);
        
        CharactorControl.SetActive(true);

        GameManager.instance.gameStarted = true;
        
        CharAnimator.enabled = true;
    }
}
