using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Navigation {mainmenu, loading, pop, count, eat, wack, slide, tip, water, avoid, spin, solve, dodge, jump, unroll};

public class GameManager : MonoBehaviour {

    public Navigation SceneNum;

    // Use this for initialization
    void Start()
    {
        SceneNum = 0;
    }
		
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ChangeScene()
    {
        switch (SceneNum)
        {
            case Navigation.mainmenu:
                Debug.Log("Switch to main menu");
                break;
            case Navigation.loading:
                Debug.Log("Switch to Loading");
                break;
            case Navigation.pop:
                Debug.Log("Switch to pop");
                break;
            case Navigation.count:
                Debug.Log("Switch to count");
                break;
            case Navigation.eat:
                Debug.Log("Switch to eat");
                break;
            case Navigation.wack:
                Debug.Log("Switch to wack");
                break;
            case Navigation.slide:
                Debug.Log("Switch to slide");
                break;
            case Navigation.tip:
                Debug.Log("Switch to tip");
                break;
            case Navigation.water:
                Debug.Log("Switch to water");
                break;
            case Navigation.avoid:
                Debug.Log("Switch to avoid");
                break;
            case Navigation.spin:
                Debug.Log("Switch to spin");
                break;
            case Navigation.solve:
                Debug.Log("Switch to solve");
                break;
            case Navigation.dodge:
                Debug.Log("Switch to dodge");
                break;
            case Navigation.jump:
                Debug.Log("Switch to jump");
                break;
            case Navigation.unroll:
                Debug.Log("Switch to unroll");
                break;
        }
    }
}
