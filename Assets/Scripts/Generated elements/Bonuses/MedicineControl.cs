using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineControl : MonoBehaviour
{
    [SerializeField] int healValue = 1;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Bomb")
        {
            Destroy(gameObject);
        }
        else if (collider.tag == "Player")
        {

            HealthSystem.instance.Heal(healValue);
            Destroy(gameObject);

        }
        
    }
}
