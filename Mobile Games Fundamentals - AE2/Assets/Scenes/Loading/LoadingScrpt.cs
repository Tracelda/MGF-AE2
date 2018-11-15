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
    public int CurrentLives;
    public StaticScrpt StaticScrpt;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;

    void Start ()
    {
        CountDown = GameObject.Find("Slider");
        Heart1 = GameObject.Find("Heart1");
        Heart2 = GameObject.Find("Heart2");
        Heart3 = GameObject.Find("Heart3");
        Heart4 = GameObject.Find("Heart4");
        CountDownSlider = CountDown.GetComponent<Slider>();
        StartLoadingTimer = true;
        TimeUp = false;
        
    }
	
	void Update ()
    {
        UpdateLives(); 
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

    public void UpdateLives()
    {
        CurrentLives = StaticScrpt.lives;
        Debug.Log("Lives: " + CurrentLives);

        if (CurrentLives == 1)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
            Heart4.SetActive(false);
        }
        else if (CurrentLives == 2)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(false);
            Heart4.SetActive(false);
        }
        else if (CurrentLives == 3)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
            Heart4.SetActive(false);
        }
        else if (CurrentLives == 4)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
            Heart4.SetActive(true);
        }
    }
}
