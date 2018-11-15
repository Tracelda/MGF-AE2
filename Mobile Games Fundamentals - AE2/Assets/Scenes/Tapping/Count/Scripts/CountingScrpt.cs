using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountingScrpt : MonoBehaviour {
    public GameObject Counter;
    public BoxCollider2D CounterColl;
    public GameObject CounterText;
    public Text CountText;
    public int Count;
    public int CountTarget;
    public string CountStrng;
    public bool GameWon;
    public bool DisableInput;
    public CountDownScrpt CountDownScrpt;
    public GameManager GameManager;

    void Start()
    {
        Counter = GameObject.Find("Counter");
        CounterColl = Counter.GetComponent<BoxCollider2D>();
        CounterText = GameObject.Find("CountText");
        CountText = CounterText.GetComponent<Text>();
        CountTarget = 5;
        DisableInput = false;
        StartTimer();
    }


    void Update()
    {
//#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            // Debug.Log("Click");
            Hit();
        }

        if (Count == CountTarget)
        {
            GameWon = true;
            // Debug.Log("Game Won");
        }
        else if (Count > CountTarget)
        {
            GameWon = false;
            // Debug.Log("Game Lost");
        }
        EndCheck();

//#elif UNITY_ANDROID

//            StartTimer();
//            if (Input.touchCount == 1)
//             {
//                Debug.Log("Click");
//                Hit();
//            }

//            if (Count == CountTarget)
//            {
//                GameWon = true;
//                Debug.Log("Game Won");
//            }
//            else if (Count > CountTarget)
//            {
//                GameWon = false;
//                Debug.Log("Game Lost");
//            }
//        EndCheck();
//#endif
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

    public void Hit()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 100f);

        if (hit && hit.collider.CompareTag("Counter") == true && Count < 10)
        {
            // Debug.Log("Counter Hit");
            // Debug.Log("Less Than 10");
            Count++;
            CountStrng = Count.ToString();
            CountText.text = "0" + CountStrng;
        }
        else if (hit && hit.collider.CompareTag("Counter") == true && Count >= 10)
        {
            // Debug.Log("Counter Hit");
            // Debug.Log("More Than 10");
            Count++;
            CountStrng = Count.ToString();
        }
    }
}
