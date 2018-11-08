﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WackScrpt : MonoBehaviour {

    public CountDownScrpt CountDownScrpt;
    public GameManager GameManager;
    public StaticScrpt StaticScrpt;
    public bool GameWon;
    public bool DisableInput;
    private Vector3 mouselocation;
    public int MolesWacked;
    public int WackTarget;
    public bool MoleAActive;
    public bool MoleBActive;
    public bool MoleCActive;





    void Start ()
    {
        DisableInput = false;
        GameWon = false;
        MoleAActive = false;
        MoleBActive = false;
        MoleCActive = false;
    }
	

	void Update ()
    {
        if (DisableInput == false)
        {
            StartTimer();
            ActivateMole();

            if (MoleAActive == true)
            {
                HammerHitA();
            }

            else if (MoleBActive == true)
            {
                HammerHitB();
            }

            else if (MoleCActive == true)
            {
                HammerHitC();
            }
        }
        else
        {
            Debug.Log("Input Disabled");
        }
        EndCheck();
    }

    public void EndCheck()
    {
        if (CountDownScrpt.TimeUp == true && GameWon == false)
        {
            Debug.Log("GameLost");
            StaticScrpt.Lives--;
            if (StaticScrpt.Lives != 0)
            {
                GameManager.LoadNextGame();
            }
            else
            {
                GameManager.LoadGameOver();
            }
            SceneManager.LoadScene(1);
        }
        else if (CountDownScrpt.TimeUp == true && GameWon == true)
        {
            Debug.Log("Game Won");
            GameManager.LoadNextGame();
        }
    }
    public void StartTimer()
    {
        CountDownScrpt.StartT();
    }

    public void ActivateMole()
    {
        if (CountDownScrpt.TimerValue >= 1)
        {
            MoleAActive = true;
            Debug.Log("Mole A Active");
        }
        if (CountDownScrpt.TimerValue >= 2)
        {
            MoleBActive = true;
            Debug.Log("Mole B Active");
        }
        if(CountDownScrpt.TimerValue >= 3)
        {
            MoleCActive = true;
            Debug.Log("Mole C Active");
        }
    }

    public void HammerHitA()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 100f);
            if (hit && hit.collider.CompareTag("MoleA") == true)
            {
                Debug.Log("Mole Hit");
                MolesWacked++;
            }
        }
        CheckWin();
    }

    public void HammerHitB()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 100f);
            if (hit && hit.collider.CompareTag("MoleB") == true)
            {
                Debug.Log("Mole Hit");
                MolesWacked++;
            }
        }
        CheckWin();
    }

    public void HammerHitC()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 100f);
            if (hit && hit.collider.CompareTag("MoleC") == true)
            {
                Debug.Log("Mole Hit");
                MolesWacked++;
            }
        }
        CheckWin();
    }

    public void CheckWin()
    {
        if (MolesWacked >= WackTarget)
        {
            GameWon = true;
            DisableInput = true;
            Debug.Log("Game Won");
        }
    }
}