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

    public void DetectSwipe()
    {
        if( Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
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
                            Debug.Log("Left");
                            Swipe = true;
                            LeftSwipe = true;
                        }
                        else
                        {
                            Debug.Log("Right");
                            Swipe = true;
                            RightSwipe = true;
                        }
                    }
                    else { Debug.Log("Horizontal Lock Active"); }
                }
                else
                {
                    if (VerticalLock == false)
                    {
                        if (LastTouchPos.y > FirstTouchPos.y)
                        {
                            Debug.Log("Up");
                            Swipe = true;
                            UpSwipe = true;
                        }
                        else
                        {
                            Debug.Log("Down");
                            Swipe = true;
                            DownSwipe = true;
                        }
                    }
                    else
                    { Debug.Log("Vertical Lock Active"); }
                } 
            }
        }
        ResetInput();
    }

    public void ResetInput()
    {
        Swipe = false;
        UpSwipe = false;
        DownSwipe = false;
        LeftSwipe = false;
        RightSwipe = false;
        Debug.Log("Reset Swipe");
    }
}
