using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorControl : MonoBehaviour
{
   
    
    
    void Start()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Bomb")
        {
            Destroy(gameObject);
        }



        else if (collider.tag == "Player")
        {

            HealthSystem.instance.activateArmor();
            Destroy(gameObject);

        }
    }
}
