using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Direction { Left, Right, Up, Down, DoNothing};

public class SimonScrpt : MonoBehaviour {
    public bool GameWon;
    public bool DisableInput;
    public CountDownScrpt CountDownScrpt;
    public GameManager GameManager;
    public StaticScrpt StaticScrpt;
    public SwipeInputScrpt SwipeInputScrpt;
    public Direction direction;
    public GameObject Text;
    public Text DirectionText;
    public int Rand;
    public int SwipeNumber;
    public int SwipeTarget;
    public bool Up;
    public bool Down;
    public bool Left;
    public bool Right;
    public bool PickNewNumber;


    void Start ()
    {
        Text = GameObject.Find("Text");
        DirectionText = Text.GetComponent<Text>();
        GameWon = false;
        PickNewNumber = true;
        StartTimer();
	}
	

	void Update ()
    {
        PickDirection();
        DisplayDirection();
        CheckDirection();
        EndCheck();
	}

    public void StartTimer()
    {
        CountDownScrpt.StartT();
    }


    public void PickDirection()
    {
        if (SwipeNumber < SwipeTarget)
        {
            Debug.Log("Pick Number");
            if (PickNewNumber == true) // Pick a random direction out of the 4
            {
                direction = (Direction)0;
                // Debug.Log("Before: " + direction);
                Rand = Random.Range(0, 4);
                direction = direction + Rand;
                // Debug.Log("After: " + direction);

                DisplayDirection();
                PickNewNumber = false;
            }
        }
        else if (SwipeNumber >= SwipeTarget)
        {
            direction = (Direction)4;
            Debug.Log("Do Nothing");
        }
    }

    public void DisplayDirection() // Edits ui text to tell plyer which way to swipe
    {
        switch (direction)
        {
            case Direction.Left:
                // Debug.Log("Left");
                DirectionText.text = "Swipe Left";
                Left = true;
                
                break;

            case Direction.Right:
                // Debug.Log("Right");
                DirectionText.text = "Swipe Right";
                Right = true;
                break;

            case Direction.Up:
                // Debug.Log("Up");
                DirectionText.text = "Swipe Up";
                Up = true;
                break;

            case Direction.Down:
                // Debug.Log("Down");
                DirectionText.text = "Swipe Down";
                Down = true;
                break;

            case Direction.DoNothing:
                DirectionText.text = "Do Nothing";
                Debug.Log("Do Nothing");
                break;
        }
    }

    public void CheckDirection() // checks direction that the player has swiped
    {
        SwipeInputScrpt.DetectSwipe();
        if ((Left == true) && (SwipeInputScrpt.LeftSwipe == true))
        {
            SwipeNumber++;
            if (SwipeNumber >= SwipeTarget)
            {
                GameWon = true;
            }
            else
            {
                PickNewNumber = true;
            }
        }
        else if ((Right == true) && (SwipeInputScrpt.RightSwipe == true))
        {
            SwipeNumber++;
            if (SwipeNumber >= SwipeTarget)
            {
                GameWon = true;
            }
            else
            {
                PickNewNumber = true;
            }
        }
        else if ((Up == true) && (SwipeInputScrpt.UpSwipe == true))
        {
            SwipeNumber++;
            if (SwipeNumber >= SwipeTarget)
            {
                GameWon = true;
            }
            else
            {
                PickNewNumber = true;
            }
        }
        else if ((Down == true) && (SwipeInputScrpt.DownSwipe == true))
        {
            SwipeNumber++;
            if (SwipeNumber >= SwipeTarget)
            {
                GameWon = true;
            }
            else
            {
                PickNewNumber = true;
            }
        }
        SwipeInputScrpt.ResetInput();
        ResetDirection();
    }

    public void ResetDirection()
    {
        Up = false;
        Down = false;
        Left = false;
        Right = false;
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
