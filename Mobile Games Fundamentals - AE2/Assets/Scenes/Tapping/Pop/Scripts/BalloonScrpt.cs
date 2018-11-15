using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BalloonScrpt : MonoBehaviour
{
    private Vector3 mouselocation;
    public int BalloonsPopped;
    public int PopTarget;
    public bool GameWon;
    public bool DisableInput;
    public CountDownScrpt CountDownScrpt;
    public GameManager GameManager;
    public StaticScrpt StaticScrpt;

    void Start()
    {
        // initilizing values
        BalloonsPopped = 0;
        PopTarget = 4;
        GameWon = false;
        DisableInput = false;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (DisableInput == false)
        {
            StartTimer();

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Click");
                // Debug to test if if statement works
                //Converting Mouse Pos to 2D (vector2) World Pos
                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 100f);

                if (hit && hit.collider.CompareTag("Balloon") == true) // Checking tag of hit sprite
                {
                    // Debug.Log("Balloon Hit");
                    Destroy(hit.transform.gameObject); // Destroy gameobject that is hit by raycast
                    BalloonsPopped++;
                }
            }

            if (BalloonsPopped >= PopTarget)
            {
                GameWon = true;
                DisableInput = true;
                // Debug.Log("Game Won");
            }

        }
        else
        {
            // Debug.Log("Input Disabled");
        }
        EndCheck();


#elif UNITY_ANDROID
         if (DisableInput == false)
         {
            StartTimer();

            if (Input.touchCount == 1)
            {
                // Debug.Log("Click");

                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 100f);

                if (hit && hit.collider.CompareTag("Balloon") == true) // Checking tag of hit sprite
                {
                // Debug.Log("Balloon Hit");
                Destroy(hit.transform.gameObject); // Destroy gameobject that is hit by raycast
                BalloonsPopped++;
                }
            }

            if(BalloonsPopped == PopTarget)
            {
                GameWon = true;
                DisableInput = false;
                // Debug.Log("Game Won");
            }
           
         }
        else
        {
            // Debug.Log("Input Disabled");
        }
         EndCheck();


#endif
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

    public void StartTimer()
    {
        CountDownScrpt.StartT();
    }
}
