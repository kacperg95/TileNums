using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    private bool swipeLeft, swipeRight, swipeUp, swipeDown, isDragged;
    private Vector2 startTouch, swipeDelta;


    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }



	
	// Update is called once per frame
	private void Update () {
        swipeLeft = swipeRight = swipeUp = swipeDown = false;

        //Kod wykrywający swipe'a na komputerze
        if(Input.GetMouseButtonDown(0))
        {
            startTouch = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Reset();
        }


        //Kod wykrywający swipe'a na smartphonie
        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                startTouch = Input.touches[0].position;
                isDragged = true;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
            }
        }


        //Kalkulacja długości swipe'a
        swipeDelta = Vector2.zero;

        if(isDragged)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if(Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        //Jeżeli swipe jest wystarczająco długi
        if(swipeDelta.magnitude > 125)
        {
            //W jakim kierunku jest swipe?

            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Lewo albo prawo
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //Góra albo dół
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }
           
            Reset();
        }


	}


    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragged = false;
    }

}
