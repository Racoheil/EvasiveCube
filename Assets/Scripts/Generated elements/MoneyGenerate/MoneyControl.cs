using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyControl : MonoBehaviour
{
   
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerBalance.instance.AddMoney(1);
            Deactivate();
        }
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
 
}
