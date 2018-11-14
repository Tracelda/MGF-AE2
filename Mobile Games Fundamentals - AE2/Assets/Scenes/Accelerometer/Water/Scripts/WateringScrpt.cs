using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WateringScrpt : MonoBehaviour {
    public Vector3 Rotation;
    public float LowLim;
    public float HighLim;
    public float LowLossLim;
    public float HighLossLim;
    public GameObject Wateringcan;
    public Rigidbody2D Rigid;
    public bool InputLock;
    public bool GameWon;
    public CountDownScrpt CountDownScrpt;
    public GameManager GameManager;

    private float Rot;
    public float Range = 10.0f;


	void Start ()
    {
        Wateringcan = GameObject.Find("WateringCan");
        Rigid = Wateringcan.GetComponent<Rigidbody2D>();
        InputLock = false;
        StartTimer();
    }

    void Update()
    {
        if (InputLock == false)
        {
            Rotate();
            CheckRotation();
        }
        else
        {
            Debug.Log("Input Locked");
        }
        EndCheck();
    }

    public void Rotate()
    {
        Rotation = new Vector3(0, 0, -Input.acceleration.x * 2);
        transform.Rotate(Rotation);
    }

    public void CheckRotation()
    {
        Debug.Log(Rot);
        Rot = gameObject.transform.rotation.eulerAngles.z;
        Pouring();
        

    }

    public void Pouring()
    {
        if ((Rot <= HighLim) && (Rot >= LowLim))
        {
            InputLock = true;
            GameWon = true;
        }
        else if ((Rot <= HighLossLim) && (Rot >= LowLossLim))
        {
            InputLock = true;
            GameWon = false;
        }

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
}
