using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScrpt : MonoBehaviour {
    public float jumpHight;
    public Rigidbody2D Rigid;

    void Start ()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Rigid.velocity = new Vector2(Rigid.velocity.y, jumpHight * Time.deltaTime);
        }

    }
}
