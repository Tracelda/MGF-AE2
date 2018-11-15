using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointScrpt : MonoBehaviour {
    public int Points;
    public int PointsTarget;
    public int Spins;
    public string SpinsString;
    public bool GameWon;
    public CountDownScrpt CountDownScrpt;
    public GameManager GameManager;
    public GameObject CountText;
    public Text CountTextVal;

	void Update ()
    {
        EndCheck();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Counter")
        {
            if (Points <= PointsTarget)
            {
                Points++;
                Spins--;
                UpdateText();
                Debug.Log("Points: " + Points);
            }
            else if (Points >= PointsTarget)
            {
                GameWon = true;
            }
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

    public void UpdateText()
    {
        if (Spins > 0)
        {
            SpinsString = Spins.ToString();
            CountTextVal.text = SpinsString;
        }
        else if (Spins <= 0)
        {
            CountTextVal.text = "0"; // stops it from going into negatives
        }

    }
}
