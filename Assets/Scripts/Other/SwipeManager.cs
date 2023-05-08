using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwipeManager : MonoBehaviour
{

    public static SwipeManager instance;
    public delegate void onSwipeHandler(int direction);

    
   
    public event onSwipeHandler onSwipeEvent;

    public enum Direction { Right,Left,Up, Down};
    bool[] swipe = new bool[4];
    Vector2 TouchPosition()
    {
        return (Vector2)Input.mousePosition;
    }
    Vector2 startTouch, swipeDelta ;
    bool touchMoved;
    bool TouchBegan() { return Input.GetMouseButtonDown(0); }
    bool TouchEnded() { return Input.GetMouseButtonUp(0); }
    bool GetTouch() { return Input.GetMouseButton(0); }
    

    [SerializeField]const float SWIPE_THRESHOLD = 50 ;
    void Awake() { instance = this; }
   
    void Update()
    {
        //START AND FINISH
        if (TouchBegan())
        {
            startTouch = TouchPosition();
            touchMoved = true;
        }
        else if (TouchEnded() && touchMoved == true)
        {
            SendSwipe();
            touchMoved = false;
        }

        //CALCULATE DISTANCE OF SWIPe
        swipeDelta = Vector2.zero;
        if (touchMoved==true && GetTouch()==true)
        {
            swipeDelta = TouchPosition() - startTouch;
        }

        //CHECK SWIPE
        if(swipeDelta.magnitude > SWIPE_THRESHOLD)
        {
            if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
            {
                //LEFT/RIGHT
                swipe[(int)Direction.Left] = swipeDelta.x < 0;
                swipe[(int)Direction.Right] = swipeDelta.x > 0;


            }
            else
            {
                //UP/DOWN
                swipe[(int)Direction.Up] = swipeDelta.y > 0;
                swipe[(int)Direction.Down] = swipeDelta.y < 0;

            }
            SendSwipe();
        }

    }
    void SendSwipe() 
    {
     for(int i=0;i<swipe.Length;i++)
        {
          //  Debug.Log("Number of direction is "+i);
            if (swipe[i] == true)
            {
                Debug.Log("Number of direction is" + i); 
               onSwipeEvent.Invoke(i);
            }
        }
        //else
        //{
        //    Debug.Log("Click");
        //}
        Reset();
    }
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        touchMoved = false;
        for(int i = 0; i < 4; i++)
        {
            swipe[i] = false;
        }
    }
}
