using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SubtitleScript : MonoBehaviour {
    public CountDownScrpt CountDownScrpt;

	void Start ()
    {
        gameObject.SetActive(true);
    }
	

	void Update ()
    {
		if (CountDownScrpt.TimerValue == 2)
        {
            gameObject.SetActive(false);
        }
	}
}
