using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Bites {none, one, two, three, four}

public class EatingScrpt : MonoBehaviour {
    public bool GameWon;
    public bool DisableInput;
    public bool BiteTaken;
    public CountDownScrpt CountDownScrpt;
    public GameManager GameManager;
    public int NumOfBites;
    public Bites BiteNum;

    public GameObject NoBites;
    public GameObject OneBite;
    public GameObject TwoBites;
    public GameObject ThreeBites;

    void Start ()
    {
        NoBites = GameObject.Find("Burger");
        OneBite = GameObject.Find("Burger1");
        TwoBites = GameObject.Find("Burger2");
        ThreeBites = GameObject.Find("Burger3");
        DisableInput = false;
        StartTimer();
    }
	
	void Update ()
    {
		if (DisableInput == false)
        {
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    IncrimentBites();
                    BiteTaken = false;
                    //DisableInput = false;
                }
            }
            EndCheck();
        }
        else
        {
            Debug.Log("Input Disabled");
        }
    }

    public void StartTimer()
    {
        CountDownScrpt.StartT();
    }

    public void IncrimentBites()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 100f);
        Debug.Log("Click");
        if (hit && hit.collider.CompareTag("Burger") == true && NumOfBites < 4)
        {
            BiteNum++;
            NumOfBites++;
            BiteTaken = true;
            TakeABite();
            Debug.Log("Bite Taken: " + BiteTaken);
        }
        else if (hit && hit.collider.CompareTag("Burger") == true && NumOfBites >= 4)
        {
            DisableInput = true;
            Debug.Log("Disable Input");
        }
    }

    public void TakeABite()
    {
        switch (BiteNum)
        {
            case Bites.none:
                NoBites.gameObject.SetActive(true);
                OneBite.gameObject.SetActive(false);
                TwoBites.gameObject.SetActive(false);
                ThreeBites.gameObject.SetActive(false);
                break;

            case Bites.one:
                NoBites.gameObject.SetActive(false);
                OneBite.gameObject.SetActive(true);
                TwoBites.gameObject.SetActive(false);
                ThreeBites.gameObject.SetActive(false);
                Debug.Log("Number Of Bites: " + NumOfBites);
                break;

            case Bites.two:
                NoBites.gameObject.SetActive(false);
                OneBite.gameObject.SetActive(false);
                TwoBites.gameObject.SetActive(true);
                ThreeBites.gameObject.SetActive(false);
                Debug.Log("Number Of Bites: " + NumOfBites);
                break;

            case Bites.three:
                NoBites.gameObject.SetActive(false);
                OneBite.gameObject.SetActive(false);
                TwoBites.gameObject.SetActive(false);
                ThreeBites.gameObject.SetActive(true);
                Debug.Log("Number Of Bites: " + NumOfBites);
                break;

            case Bites.four:
                NoBites.gameObject.SetActive(false);
                OneBite.gameObject.SetActive(false);
                TwoBites.gameObject.SetActive(false);
                ThreeBites.gameObject.SetActive(false);
                Debug.Log("Number Of Bites: " + NumOfBites);
                GameWon = true;
                break;


        }
    }

    public void EndCheck()
    {
        if (CountDownScrpt.TimeUp == true && GameWon == false)
        {
            Debug.Log("GameLost");
            StaticScrpt.lives--;
            if (StaticScrpt.lives > 0)
            {
                GameManager.LoadNextGame();
            }
            else
            {
                GameManager.LoadGameOver();
                Debug.Log("Load Game Over");
            }

        }
        else if (CountDownScrpt.TimeUp == true && GameWon == true)
        {
            Debug.Log("Game Won");
            GameManager.LoadNextGame();
        }
    }
}
