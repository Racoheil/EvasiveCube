using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheckRaycast : MonoBehaviour
{
    public bool grounded = false;
    public float groundedCheckDistance = 1f;
    private float bufferCheckDistance = 0.1f;
    public static groundCheckRaycast instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
       // groundedCheckDistance = (GetComponent<CapsuleCollider>().height / 2) + bufferCheckDistance;
      //  groundedCheckDistance = (GetComponent<BoxCollider>().size.y / 2) + bufferCheckDistance;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, groundedCheckDistance)){
            grounded = true;
        }
        else
        {
            grounded = false;
        }

    }

}
