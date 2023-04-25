using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineControl : MonoBehaviour
{
    [SerializeField] int healValue = 1;
    float lifeTime =15f;
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
    private void OnEnable()
    {
        this.StartCoroutine("LifeRoutine");
    }
    private void OnDisable()
    {
        this.StopCoroutine("LifeRoutine");
    }
    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSeconds(lifeTime);
        this.Deactivate();
    }
    void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
