using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheckRaycast : MonoBehaviour
{
    public bool grounded = false;
    public float groundedCheckDistance = 1f;

    public static groundCheckRaycast instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
     
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, groundedCheckDistance)){
            grounded = true;
        }
        else
        {
            grounded = false;
            playerMove2.instance.playerFall();
        }

    }

}
