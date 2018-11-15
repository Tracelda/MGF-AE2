using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvoidScrpt : MonoBehaviour {

    private Vector3 mouselocation;
    public GameObject Movable;
    public GameObject FallingPrefab;
    public Rigidbody2D Rigid;
    public bool Moving;
    public bool Pickedup;
    public bool GameLost;
    public bool Spawned;
    public CountDownScrpt CountDownScrpt;
    public GameManager GameManager;
    public float FallPos;
    public float ScreenLeft;
    public float ScreenRight;
    public float FallHight;
    

    void Start ()
    {
        
        Movable = GameObject.Find("Movable");
        Rigid = Movable.GetComponent<Rigidbody2D>();
        Moving = false;
        Pickedup = false;
        ScreenLeft = -2.30f;
        ScreenRight = 2.3f;
        FallHight = 5f;
        StartTimer();
        InstantiateFallingObject();
    }
	

	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RayCast();
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
        // Debug.Log("Put Down");
    }

    public void StartTimer()
    {
        CountDownScrpt.StartT();
    }

    public void EndCheck()
    {
        if (CountDownScrpt.TimeUp == true && GameLost == true)
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
            
        }
        else if (CountDownScrpt.TimeUp == true && GameLost == false)
        {
            Debug.Log("Game Won");
            GameManager.LoadNextGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameLost = true;
        // Debug.Log("Collission");
    }

    private void InstantiateFallingObject()
    {
        if (Spawned == false)
        {
            FallPos = Random.Range(ScreenLeft, ScreenRight);
            Instantiate(FallingPrefab, new Vector2(FallPos, FallHight), Quaternion.identity);
            Spawned = true;
        }
    }
}
