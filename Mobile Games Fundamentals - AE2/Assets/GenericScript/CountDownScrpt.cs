using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownScrpt : MonoBehaviour {
    public GameObject CountDown;
    public Slider CountDownSlider;
    public bool StartTimer;
    public bool TimeUp;
    public float TimerValue;
    public float TimerTarget;

	void Start ()
    {
        CountDown = GameObject.Find("Slider");
        CountDownSlider = CountDown.GetComponent<Slider>();
        StartTimer = false;
        TimeUp = false;
	}
	

	void Update ()
    {
		if (StartTimer == true && TimerValue < TimerTarget)
        {
            TimerValue += Time.deltaTime;
            CountDownSlider.value = TimerValue;

            if (TimerValue >= TimerTarget)
            {
                StartTimer = false;
                TimeUp = true;
                Debug.Log("TimeUp");
            }
        }
	}

    public void StartT()
    {
        StartTimer = true;
    }
}
