using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScrpt : MonoBehaviour {
    public ThrowBall ThrowBall;
    public bool Hit;
    private Vector3 Home;
    public GameObject ReturnSpot;
    public GameObject Player;


	void Start ()
    {
        Hit = false;
        ReturnSpot = GameObject.Find("Home");
        Home = ReturnSpot.transform.position;
	}
	

	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Debug.Log("Goal Scored");
            ThrowBall.GoalsScored++;
            Hit = true;
            Move();
        }
    }

    public void Move()
    {
        if (Hit == true)
        {
            Player.transform.position = new Vector3(Home.x, Home.y, Home.z);
            Hit = false;
        }
    }
}
