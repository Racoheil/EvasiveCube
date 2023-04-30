using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Finish!");
            LoseWinManager.instance.playerWin();
            //cellControl.hitCell();
            

        }


    }
}
