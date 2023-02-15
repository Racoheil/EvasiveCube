using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    //[SerializeField] private playerMove playerMove;
    [SerializeField] private Vector3 cellPosition;
    
 
    private void OnTriggerEnter(Collider collider)
    {
       // Debug.Log("Коснулся чего-то, брат");
        if (collider.gameObject.tag == "Cell")
        {
            playerMove.instance.IsGrounded = true;
            cellPosition = collider.transform.position;
           if (playerMove.instance.isCorrect) { playerMove.instance.positionCorrect(cellPosition); }

           // Debug.Log("Correct position, broh");
        }
    }
    //private void OnTriggerExit(Collider collider)
    //{
    //    if(collider.gameObject.tag == "Cell")
    //    {
    //        playerMove.instance.IsGrounded = false;
    //    }
    //}
}
