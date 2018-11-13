using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewJumpScrpt : MonoBehaviour {
    public CountDownScrpt CountDownScrpt;
    public GameManager GameManager;
    public SwipeInputScrpt SwipeInputScrpt;
    public GameObject Player;
    public Rigidbody2D PlayerRigid;
    public bool GameWon;
    public bool JumpResult;
    public int JumpHight;


    void Start ()
    {
        //StartTimer();
    }
	

	void Update ()
    {
        SwipeInputScrpt.DetectSwipe();
        JumpResult = SwipeInputScrpt.DetectSwipe();
        Debug.Log(JumpResult);
        if (JumpResult == true)
        {
            Jump();
        }

        EndCheck();
	}

    public void StartTimer()
    {
        CountDownScrpt.StartT();
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

    public void Jump()
    {
        PlayerRigid.velocity = new Vector2(PlayerRigid.velocity.y, JumpHight * Time.deltaTime);
    }

}
