using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorControl : Bonus
{
  
    private void OnTriggerEnter(Collider collider)
    {
       

        if (collider.tag == "Player")
        {

            HealthSystem.instance.activateArmor();
            Deactivate();

        }
    }
}
