using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove2 : MonoBehaviour
{
    public Vector3 targetPosition;
    public float interpTime;
    public float step=0.05f;
    public float speed = 1.0f;
    void FixedUpdate()
    {


        //if (/*isGrounded &&*/ Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        //}
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
        



    }

}
