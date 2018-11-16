using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour {
    public CountDownScrpt CountDownScrpt;
    public GameManager GameManager;
    public SwipeInputScrpt SwipeInputScrpt;
    public GameObject Player;
    public Rigidbody2D PlayerRigid;
    public bool GameWon;
    public bool JumpResult;
    public int JumpHight;
    public float RayLength;
    public int GoalsScored;
    public int GoalTarget;

    void Start ()
    {
        GoalsScored = 0;
        GoalTarget = 4;
	}
	

	void Update ()
    {
        SwipeInputScrpt.DetectSwipe();
        JumpResult = SwipeInputScrpt.DetectSwipe();
        // Debug.Log(JumpResult);
        if (JumpResult == true)
        {
            Jump();
        }
        CheckScore();
        EndCheck();
    }

    public void StartTimer()
    {
        CountDownScrpt.StartT();
    }

    public void Jump()
    {
        if (Physics2D.Linecast(transform.position, transform.position + new Vector3(0, RayLength, 0), 1 << LayerMask.NameToLayer("Floor")))
        {
            PlayerRigid.velocity = new Vector2(PlayerRigid.velocity.y, JumpHight * Time.deltaTime);
        }
    }

    public void CheckScore()
    {
        if(GoalsScored >= GoalTarget)
        {
            GameWon = true;
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
