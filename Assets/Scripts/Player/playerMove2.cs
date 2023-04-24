using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove2 : MonoBehaviour
{
    public Vector3 targetPosition;
    //public float interpTime;
    public float step=0.01f;
    public float speed = 10.0f;
    private bool isDone = true;
    Rigidbody rb;
    public static playerMove2 instance;
    //public int[] speeds;
    public bool isMove = true;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
       
        //speeds = new int[6]{ 5, 15, 25, 35, 45,50 };
        targetPosition = transform.position + new Vector3(0, 0, 1.3f);
        rb = GetComponent<Rigidbody>();
        SwipeManager.instance.onSwipeEvent += Move;


    }
    public void Move(int direct)
    {
        if (isDone && isMove)
        {
            switch (direct)
            {
                case 0:
                    targetPosition = transform.position + new Vector3(1.3f, 0, 0);
                    StartCoroutine("playerMove");
                    break;
                case 1:
                    targetPosition = transform.position + new Vector3(-1.3f, 0, 0);
                    StartCoroutine("playerMove");
                    break;
                case 2:
                    targetPosition = transform.position + new Vector3(0, 0, 1.3f);
                    StartCoroutine("playerMove");
                    break;
                case 3:
                    targetPosition = transform.position + new Vector3(0, 0, -1.3f);
                    StartCoroutine("playerMove");
                    break;
                case 4:
                    
                    break;

            }
        }

        //isGrounded = false;
    }
    void Update()
    {


        if (isDone && Input.GetKeyDown(KeyCode.RightArrow))
        {


            targetPosition = transform.position + new Vector3(1.3f, 0, 0);
            StartCoroutine("playerMove");
        }
        if (isDone && Input.GetKeyDown(KeyCode.LeftArrow))
        {


            targetPosition = transform.position + new Vector3(-1.3f, 0, 0);
            StartCoroutine("playerMove");

        }
        if (isDone && Input.GetKeyDown(KeyCode.UpArrow))
        {


            targetPosition = transform.position + new Vector3(0, 0, 1.3f);
            StartCoroutine("playerMove");

        }
        if (isDone && Input.GetKeyDown(KeyCode.DownArrow))
        {


            targetPosition = transform.position + new Vector3(0, 0, -1.3f);
            StartCoroutine("playerMove");

        }
        if (groundCheckRaycast.instance.grounded == false)
        {
            playerFall();
            Debug.Log("Падай!");
        }



    }
    void playerFall()
    {
        StopAllCoroutines();
        rb.useGravity = true;
        rb.freezeRotation = false;
    }
    IEnumerator playerMove()
    {
        if (isMove)
        {
            isDone = false;




            while (transform.position != targetPosition)
            {

                var step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

                yield return new WaitForSeconds(0.001f);
            }
            isDone = true;
        }

    }
    public void changeSpeed(int value)
    {
        speed += value;
    }
}
