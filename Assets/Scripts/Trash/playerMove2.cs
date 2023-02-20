using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove2 : MonoBehaviour
{
    public Vector3 targetPosition;
    //public float interpTime;
    public float step=0.01f;
    public float speed = 10.0f;
    private void Start()
    {
        targetPosition = transform.position + new Vector3(0, 0, 1.3f);
    }
    void Update()
    {


        if (/*isDone && */Input.GetKeyDown(KeyCode.RightArrow))
        {


            targetPosition = transform.position + new Vector3(1.3f, 0, 0);
            StartCoroutine("playerMove");
        }
        if (/*isDone &&  */Input.GetKeyDown(KeyCode.LeftArrow))
        {


            targetPosition = transform.position + new Vector3(-1.3f, 0, 0);
            StartCoroutine("playerMove");

        }
        if (/*isDone && */Input.GetKeyDown(KeyCode.UpArrow))
        {


            targetPosition = transform.position + new Vector3(0, 0, 1.3f);
            StartCoroutine("playerMove");

        }
        if (/*isDone &&*/ Input.GetKeyDown(KeyCode.DownArrow))
        {
            

            targetPosition = transform.position + new Vector3(0, 0, -1.3f);
            StartCoroutine("playerMove");

        }




    }
    IEnumerator playerMove()
    {
       

        while (transform.position != targetPosition)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            
            yield return new WaitForSeconds(0.001f);
        }
        
    }
}
