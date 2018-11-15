using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCollision : MonoBehaviour {
    public CountDownScrpt CountDownScrpt;
    public GameManager GameManager;
    public bool GameWon;
    private void Start()
    {
        StartTimer();
        GameWon = false;
    }

    private void Update()
    {
        EndCheck();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Flag")
        {
            Debug.Log("Collision");
            GameWon = true;
        }
        else
        {
            GameWon = false;
        }
    }

    public void StartTimer()
    {
        CountDownScrpt.StartT();
    }

    public void EndCheck()
    {
        if (CountDownScrpt.TimeUp == true && GameWon == true)
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

        }
        else if (CountDownScrpt.TimeUp == true && GameWon == false)
        {
            Debug.Log("Game Won");
            GameManager.LoadNextGame();
        }
    }
}
