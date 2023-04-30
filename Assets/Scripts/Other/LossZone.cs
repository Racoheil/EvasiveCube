using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("GameOver");
            LoseWinManager.instance.playerLose();
            //cellControl.hitCell();


        }


    }
}
