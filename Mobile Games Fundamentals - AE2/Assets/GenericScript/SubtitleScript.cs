using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SubtitleScript : MonoBehaviour {
    public CountDownScrpt CountDownScrpt;
    public GameObject Input;

	void Start ()
    {
        Input = GameObject.Find("Input");
        Input.SetActive(true);
        gameObject.SetActive(true);
    }
	

	void Update ()
    {
		if (CountDownScrpt.TimerValue >= 2)
        {
            gameObject.SetActive(false);
            Input.SetActive(false);
        }
	}
}
