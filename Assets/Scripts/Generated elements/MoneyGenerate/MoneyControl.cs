using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyControl : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("+1");
            PlayerBalance.instance.AddMoney(1);
            Deactivate();
        }
        else if (collision.gameObject.tag == "Bonus")
        {
            Deactivate();
        }
        Deactivate();



    }
   
    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
 
}
