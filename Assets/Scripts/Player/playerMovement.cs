using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private Vector3 endPosition = new Vector3(5, -2, 0);
    private Vector3 startPosition;
    [SerializeField] private float desiredDuration = 0.2f;
    private float elapsedTime;
    private bool isDone = true;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isDone && Input.GetKeyDown(KeyCode.RightArrow))
        {
            elapsedTime = 0;

            endPosition = transform.position + new Vector3(1.3f, 0, 0);
            StartCoroutine("playerMove");
        }
        if (isDone &&  Input.GetKeyDown(KeyCode.LeftArrow))
        {
            elapsedTime = 0;

            endPosition = transform.position + new Vector3(-1.3f, 0, 0);
            StartCoroutine("playerMove");
           
        }
        if (isDone && Input.GetKeyDown(KeyCode.UpArrow))
        {
            elapsedTime = 0;

            endPosition = transform.position + new Vector3(0, 0, 1.3f);
            StartCoroutine("playerMove");
           
        }
        if (isDone && Input.GetKeyDown(KeyCode.DownArrow))
        {
            elapsedTime = 0;

            endPosition = transform.position + new Vector3(0, 0, -1.3f);
            StartCoroutine("playerMove");
            
        }
       
        //elapsedTime += Time.deltaTime;
        //float percentageComplete = elapsedTime / desiredDuration;
        //transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
    }
    
    IEnumerator playerMove()
    {
        isDone = false;
        
        while (transform.position != endPosition)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;
            transform.position = Vector3.Lerp(transform.position, endPosition, percentageComplete);
            yield return new WaitForSeconds(0.02f);
        }
        isDone = true;
       // groundCheck();
    }
}
