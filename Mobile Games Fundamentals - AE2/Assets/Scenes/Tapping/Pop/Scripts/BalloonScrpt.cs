using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScrpt : MonoBehaviour
{
    private Vector3 mouselocation;
    public int BalloonsPopped;
    public int PopTarget;
    public bool GameWon;

    void Start()
    {
        // initilizing values
        BalloonsPopped = 0;
        PopTarget = 4;
        GameWon = false;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            // Debug to test if if statement works
            //Converting Mouse Pos to 2D (vector2) World Pos
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 100f);

            if (hit && hit.collider.CompareTag("Balloon") == true) // Checking tag of hit sprite
            {
                Debug.Log("Balloon Hit");
                Destroy(hit.transform.gameObject); // Destroy gameobject that is hit by raycast
                BalloonsPopped++;
            }
        }

        if(BalloonsPopped == PopTarget)
        {
            GameWon = true;
            Debug.Log("Game Won");
        }

#elif UNITY_ANDROID
                if (Input.touchCount == 1)
        {
            Debug.Log("Click");

            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 100f);

            if (hit && hit.collider.CompareTag("Balloon") == true) // Checking tag of hit sprite
            {
                Debug.Log("Balloon Hit");
                Destroy(hit.transform.gameObject); // Destroy gameobject that is hit by raycast
                BalloonsPopped++;
            }
        }

        if(BalloonsPopped == PopTarget)
        {
            GameWon = true;
            Debug.Log("Game Won");
        }
#endif
    }
}
