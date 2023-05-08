using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Коснулся стены");
            playerMove2.instance.playerFall();
            playerMove2.instance.playerFly();
            LoseWinManager.instance.playerLose();
        }
    }
}
