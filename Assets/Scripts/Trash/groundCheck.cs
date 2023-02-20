using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    //[SerializeField] private playerMove playerMove;
    [SerializeField] private Vector3 cellPosition;
    
 
    //private void OnTriggerEnter(Collider collider)
    //{
    //   // Debug.Log("Коснулся чего-то, брат");
    //    if (collider.gameObject.tag != "Cell"&&collider.gameObject.tag=="LossZone")
    //    {
    //        playerMove.instance.IsGrounded = false;
    //       // cellPosition = collider.transform.position;
    //     //  if (playerMove.instance.isCorrect) { playerMove.instance.positionCorrect(cellPosition); }

    //       // Debug.Log("Correct position, broh");
    //    }
        
    //}
    private void OnTriggerEnter(Collider collider)
    {
        if (/*collider.gameObject.tag == "Cell" &&*/ collider.gameObject.tag == "LossZone")
        {
            Debug.Log("Баста");
            playerMove.instance.IsGrounded = false;
            // cellPosition = collider.transform.position;
            //  if (playerMove.instance.isCorrect) { playerMove.instance.positionCorrect(cellPosition); }

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
