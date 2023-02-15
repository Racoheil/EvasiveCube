using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraMovement : MonoBehaviour
{
    public Transform Target;
    Vector3 difDisctance, moveVec, startPosition;

    void Start()
    {
        startPosition = transform.position;
        difDisctance = transform.position - Target.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        moveVec = Target.position + difDisctance;

       
        moveVec.y = startPosition.y;
        transform.position = moveVec;
       

    }
    
}
