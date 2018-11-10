using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Navigation {mainmenu, loading, pop, water, avoid, count, jump, slide, wack, dodge, gameover };

public class GameManager : MonoBehaviour {

    public Navigation SceneNum;
    public StaticScrpt StaticScrpt;

    // Use this for initialization
    void Start()
    {
        SceneNum = 0;
    }

    public void ChangeScene()
    {
        switch (SceneNum)
        {
            case Navigation.mainmenu:
                Debug.Log("Switch to main menu");
                SceneManager.LoadScene(0);
                break;

            case Navigation.loading:
                Debug.Log("Switch to Loading");
                SceneManager.LoadScene(1);
                break;

            case Navigation.pop:
                Debug.Log("Switch to pop");
                SceneManager.LoadScene(2);
                break;

            case Navigation.water:
                Debug.Log("Switch to water");
                SceneManager.LoadScene(8);
                break;

            case Navigation.avoid:
                Debug.Log("Switch to avoid");
                SceneManager.LoadScene(9);
                break;

            case Navigation.count:
                Debug.Log("Switch to count");
                SceneManager.LoadScene(3);
                break;

            case Navigation.jump:
                Debug.Log("Switch to jump");
                SceneManager.LoadScene(13);
                break;

            case Navigation.slide:
                Debug.Log("Switch to slide");
                SceneManager.LoadScene(6);
                break;

            case Navigation.wack:
                Debug.Log("Switch to wack");
                SceneManager.LoadScene(5);
                break;

            case Navigation.dodge:
                Debug.Log("Switch to dodge");
                SceneManager.LoadScene(12);
                break;

            //case Navigation.tip:
            //    Debug.Log("Switch to tip");
            //    SceneManager.LoadScene(7);
            //    break;

            //case Navigation.spin:
            //    Debug.Log("Switch to spin");
            //    SceneManager.LoadScene(10);
            //    break;

            //case Navigation.eat:
            //    Debug.Log("Switch to eat");
            //    SceneManager.LoadScene(4);
            //    break;

            //case Navigation.unroll:
            //    Debug.Log("Switch to unroll");
            //    SceneManager.LoadScene(14);
            //    break;

            //case Navigation.solve:
            //    Debug.Log("Switch to solve");
            //    SceneManager.LoadScene(11);
            //    break;

            case Navigation.gameover:
                SceneManager.LoadScene(15);
                break;
        }
    }

    public void LoadFirstGame()
    {
        SceneNum = (Navigation)2; // loads first game pop
        StaticScrpt.currentGame = 2; // pop is scene number 2
        ChangeScene();

    }

    public void LoadNextGame()
    {
        SceneNum = (Navigation)1; // loads loading scene
        Debug.Log("Before ++:" + StaticScrpt.currentGame);
        StaticScrpt.currentGame++;
        Debug.Log("After ++:" + StaticScrpt.currentGame);
        ChangeScene();
    }

    public void LoadGameOver()
    {
        SceneNum = (Navigation)15;
    }

    public void SetSceneNo(int SceneNumber)
    {
        SceneNum = (Navigation)SceneNumber;
    }
}
