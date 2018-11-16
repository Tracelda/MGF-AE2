using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzleScrpt : MonoBehaviour {
    public CountDownScrpt CountDownScrpt;
    public GameManager GameManager;
    public bool GameWon;
    public GameObject Movable;
    public Rigidbody2D Rigid;
    public bool Inputlock;
    public bool Moving;
    public bool Pickedup;
    private Vector3 mouselocation;

    void Start ()
    {
        Movable = GameObject.Find("PuzlePeice");
        Rigid = Movable.GetComponent<Rigidbody2D>();
        Moving = false;
        Pickedup = false;
        StartTimer();
    }
	

	void Update ()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                RayCast();
            }
        }
        if (Moving == true)
        {
            Pickup();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Rigid.bodyType = RigidbodyType2D.Kinematic;
            PutDown();
            Rigid.velocity = Vector2.zero;
        }
        EndCheck();
    }

    public void StartTimer()
    {
        CountDownScrpt.StartT();
    }

    public void RayCast() // detects if moveable object has been hit
    {
        // Debug.Log("Click"); 
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

        if (hit.collider.CompareTag("Movable") == true)
        {
            Moving = true;
        }
    }

    public void Pickup()
    {
        Pickedup = true;
        mouselocation = Input.mousePosition;
        mouselocation.z = 10f; // used to set the distance that the object is placed infront of the camera when moving
        Rigid.transform.position = Camera.main.ScreenToWorldPoint(mouselocation);
        Rigid.bodyType = RigidbodyType2D.Dynamic;
        // Debug.Log("Pick Up");
    }

    public void PutDown()
    {
        Moving = false;
        Pickedup = false;
        Rigid.bodyType = RigidbodyType2D.Kinematic;
        // Debug.Log("Put Down");
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
