using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinScrpt : MonoBehaviour {

    public CountDownScrpt CountDownScrpt;
    public GameManager GameManager;
    public bool GameWon;
    public Rigidbody2D Rigid;
    public bool Inputlock;
    public float speed;
    void Start()
    {
        StartTimer();
        Inputlock = false;
    }

    void Update()
    {
        if (Inputlock == false)
        {
            Rigid.velocity = new Vector2((Input.acceleration.x * speed) * Time.deltaTime, Rigid.velocity.y);
        }

    }

    public void StartTimer()
    {
        CountDownScrpt.StartT();
    }
}
