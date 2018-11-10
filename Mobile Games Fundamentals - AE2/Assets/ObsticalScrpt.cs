using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalScrpt : MonoBehaviour {
    public float MoveSpeed;
    public Rigidbody2D ObsticalRigid;

    void Start ()
    {
        ObsticalRigid = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        ObsticalRigid.velocity = new Vector2(MoveSpeed * Time.deltaTime, ObsticalRigid.velocity.y);	
	}
}
