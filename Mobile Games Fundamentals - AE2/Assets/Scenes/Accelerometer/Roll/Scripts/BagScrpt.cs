using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BagScrpt : MonoBehaviour {
    public CountDownScrpt CountDownScrpt;
    public GameManager GameManager;
    public bool GameWon;
    private void Start()
    {
        GameWon = false;
    }

    private void Update()
    {
        EndCheck();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log("Collision");
            Destroy(collision.transform.gameObject);
            GameWon = true;
        }
        else
        {
            GameWon = false;
        }
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
            SceneManager.LoadScene(1); // loads main menu
        }
        else if (CountDownScrpt.TimeUp == true && GameWon == true)
        {
            Debug.Log("Game Won");
            GameManager.LoadNextGame();
        }
    }
}
