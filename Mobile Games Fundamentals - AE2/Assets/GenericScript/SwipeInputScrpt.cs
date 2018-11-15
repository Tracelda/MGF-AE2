using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeInputScrpt : MonoBehaviour {
    private Vector3 FirstTouchPos;
    private Vector3 LastTouchPos;
    public int SwipePercentage;
    private float Distance;
    public bool VerticalLock;
    public bool HorizontalLock;
    public bool Swipe;
    public bool UpSwipe;
    public bool DownSwipe;
    public bool LeftSwipe;
    public bool RightSwipe;

    private void Start()
    {
        ResetInput();
    }

    public bool DetectSwipe()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                FirstTouchPos = touch.position;
                LastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                LastTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                LastTouchPos = touch.position;

                if (Mathf.Abs(LastTouchPos.x - FirstTouchPos.x) > Mathf.Abs(LastTouchPos.y - FirstTouchPos.y)) // Check if horizontal or vertical
                {
                    if (HorizontalLock == false)
                    {
                        if ((LastTouchPos.x < FirstTouchPos.x))
                        {
                            // Debug.Log("Player Swiped Left");
                            Swipe = true;
                            LeftSwipe = true;
                            RightSwipe = false;
                            UpSwipe = false;
                            DownSwipe = false;
                        }
                        else
                        {
                            // Debug.Log("Player Swiped Right");
                            Swipe = true;
                            LeftSwipe = false;
                            RightSwipe = true;
                            UpSwipe = false;
                            DownSwipe = false;
                        }
                    }
                    else { /*Debug.Log("Horizontal Lock Active");*/ }
                }
                else
                {
                    if (VerticalLock == false)
                    {
                        if (LastTouchPos.y > FirstTouchPos.y)
                        {
                            // Debug.Log("Player Swiped Up");
                            Swipe = true;
                            LeftSwipe = false;
                            RightSwipe = false;
                            UpSwipe = true;
                            DownSwipe = false;
                        }
                        else
                        {
                            // Debug.Log("Player Swiped Down");
                            Swipe = true;
                            LeftSwipe = false;
                            RightSwipe = false;
                            UpSwipe = false;
                            DownSwipe = true;
                        }
                    }
                    else
                    {
                        // Debug.Log("Vertical Lock Active");
                        Swipe = false;

                    }
                }
            }
        }
        else
        {
            Swipe = false;
        } 
        return Swipe;
    }

    public void ResetInput()
    {
        Swipe = false;
        UpSwipe = false;
        DownSwipe = false;
        LeftSwipe = false;
        RightSwipe = false;
        // Debug.Log("Reset Swipe");
    }
}
