using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScrpt : MonoBehaviour {
    public GameObject CountDown;
    public Slider CountDownSlider;
    public bool StartLoadingTimer;
    public bool TimeUp;
    public float TimerValue;
    public float TimerTarget;
    public GameManager GameManager;

    void Start ()
    {
        CountDown = GameObject.Find("Slider");
        CountDownSlider = CountDown.GetComponent<Slider>();
        StartLoadingTimer = true;
        TimeUp = false;
        
    }
	
	void Update ()
    {
        if (StartLoadingTimer == true && TimerValue < TimerTarget)
        {
            TimerValue += Time.deltaTime;
            CountDownSlider.value = TimerValue;

            if (TimerValue >= TimerTarget)
            {
                StartLoadingTimer = false;
                TimeUp = true;
                Debug.Log("TimeUp");
                StartNextGame();
            }
        }
    }

    public void StartNextGame()
    {
        GameManager.SetSceneNo(StaticScrpt.currentGame);
        GameManager.ChangeScene();
    }
}
