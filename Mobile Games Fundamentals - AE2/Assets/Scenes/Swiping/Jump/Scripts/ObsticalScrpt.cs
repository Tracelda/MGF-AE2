using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObsticalScrpt : MonoBehaviour {
    public float MoveSpeed;
    public GameObject Obstical;
    public Rigidbody2D ObsticalRigid;
    public NewJumpScrpt NewJumpScrpt;
    public CountDownScrpt CountDownScrpt;


    void Start ()
    {
        Obstical = GameObject.Find("obstical");
        ObsticalRigid = Obstical.GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        ObsticalRigid.velocity = new Vector2(MoveSpeed * Time.deltaTime, ObsticalRigid.velocity.y);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision");
            NewJumpScrpt.GameWon = false;
        }
    }

   

   
}
