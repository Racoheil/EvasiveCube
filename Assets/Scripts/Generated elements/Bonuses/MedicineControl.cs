using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineControl : Bonus
{
    [SerializeField] int healValue = 1;
    //float lifeTime =15f;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Bomb")
        {
            //Destroy(gameObject);
          //  Deactivate();
        }
        else if (collider.tag == "Player")
        {

            HealthSystem.instance.Heal(healValue);
            Destroy(gameObject);
            Deactivate();
        }
        
    }
    private void Start()
    {
        healValue = HealthSystem.instance.GetMaxHealth()/3; 
    }


}
