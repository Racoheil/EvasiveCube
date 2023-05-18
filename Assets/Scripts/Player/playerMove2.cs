using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove2 : MonoBehaviour
{
    public Vector3 targetPosition;
   
    public float step=0.01f;
    public float speed = 10.0f;
    private bool isDone = true;
    Rigidbody rb;
    public static playerMove2 instance;
    public bool isMove = true;
    void Awake()
    {
        instance = this;
    }
    //void Update()
    //{
    //    if (/*isGrounded &&*/ isDone && isMove&&Input.GetKeyDown(KeyCode.RightArrow))
    //    {

    //        Move(0);


    //    }
    //    if (/*isGrounded &&*/isDone && isMove && Input.GetKeyDown(KeyCode.LeftArrow))
    //    {

    //        Move(1);

    //    }
    //    if (/*isGrounded &&*/ isDone && isMove && Input.GetKeyDown(KeyCode.UpArrow))
    //    {

    //        Move(2);
    //    }
    //    if (/*isGrounded &&*/isDone && isMove && Input.GetKeyDown(KeyCode.DownArrow))
    //    {

    //        Move(3);


    //    }
    //    if (/*isGrounded &&*/ isDone && isMove && Input.GetKeyDown(KeyCode.Space))
    //    {

    //        Move(4);


    //    }
    //}
    private void Start()
    {
   
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

        
    }
   public void offMove()
    {
        isMove = false;
    }
  public void playerFall()
    {
        Debug.Log("Кирдык мне");
        cameraMovement.instance.stopMove();
        StopAllCoroutines();
        rb.useGravity = true;
        rb.freezeRotation = false;
        rb.constraints = RigidbodyConstraints.None;
    }
  // public void PlayerUnfree
    public void playerFly()
    {
      
        rb.AddForce(new Vector3(0,20f,0)*400);
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
    public void addSpeed(int value)
    {
        
        speed += value;
    }
    
}
