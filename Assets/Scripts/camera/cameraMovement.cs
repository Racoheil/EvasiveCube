using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    bool isMove;
    public static cameraMovement instance;
    private void Awake()
    {
        instance = this;
        

    }
    void Start()
    {
        isMove = true;
    }
    public void stopMove()
    {
        isMove = false;
    }
    private void LateUpdate()
    {
        if (isMove)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(target);
        }
    }

  
}
