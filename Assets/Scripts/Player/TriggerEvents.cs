using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvents : MonoBehaviour
{
  public delegate void TriggerEventHandler();
    public event TriggerEventHandler moneyTakeEvent;
   public static TriggerEvents singleton;
    private void Awake()
    {
        singleton = this;
        


    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Money")
        {
            other.gameObject.SetActive(false);
            Debug.Log("Событие - взял монету");
            moneyTakeEvent?.Invoke();
        }
    }

}
