using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerScrpt : MonoBehaviour {
    public CountDownScrpt CountDownScrpt;
    public GameManager GameManager;
    public bool GameLost;
    public bool Moving;
    public GameObject Spinner;
    public Vector3 MousePos;
    public float Angle;


    void Start ()
    {
        Spinner = GameObject.Find("Spinner");
        StartTimer();
    }
	
	// Update is called once per frame
	void Update ()
    {
        RayCast();
        FollowMouse();
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

        if (hit && hit.collider.CompareTag("Movable") == true)
        {
            Moving = true;
        }
    }

    public void FollowMouse()
    {
        if (Moving == true)
        {
            MousePos = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            Angle = Mathf.Atan2(MousePos.y, MousePos.x) * Mathf.Rad2Deg;
            Spinner.transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
        }
    }
}
