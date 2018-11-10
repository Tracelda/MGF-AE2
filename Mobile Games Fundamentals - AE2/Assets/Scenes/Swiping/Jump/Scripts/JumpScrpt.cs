using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpScrpt : MonoBehaviour {
 //   public float jumpHight;
 //   public Rigidbody2D Rigid;
 //   public CountDownScrpt CountDownScrpt;
 //   public GameManager GameManager;
 //   public bool GameWon;

 //   void Start ()
 //   {
 //       Rigid = GetComponent<Rigidbody2D>();
 //       //CountDownScrpt.StartTimer = true;
 //       StartTimer();
 //   }
	
	//// Update is called once per frame
	//void Update ()
 //   {
 //       if(Input.GetMouseButtonDown(0))
 //       {
 //           Rigid.velocity = new Vector2(Rigid.velocity.y, jumpHight * Time.deltaTime);
 //       }
 //       EndCheck();
 //   }

 //   public void EndCheck()
 //   {
 //       Debug.Log("EndCheck");
 //       if (CountDownScrpt.TimeUp == true && GameWon == false)
 //       {
 //           Debug.Log("GameLost");
 //           StaticScrpt.Lives--;
 //           if (StaticScrpt.Lives != 0)
 //           {
 //               GameManager.LoadNextGame();
 //           }
 //           else
 //           {
 //               GameManager.LoadGameOver();
 //           }
 //           SceneManager.LoadScene(10);
 //       }
 //       else if (CountDownScrpt.TimeUp == true && GameWon == true)
 //       {
 //           Debug.Log("Game Won");
 //           GameManager.LoadNextGame();
 //       }
 //   }
 //   public void StartTimer()
 //   {
 //       CountDownScrpt.StartT();
 //       Debug.Log("Start Timer");
 //   }
}
