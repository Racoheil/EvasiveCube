using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatCellControl : MonoBehaviour
{
    [SerializeField] Material heat1, heat2, heat3;
    MeshRenderer meshRenderer;
    public float WaitForSeconds=100;
    [SerializeField] int state;
    [SerializeField] GameObject player;
    void Start()
    {
        state = 0;
        //  meshRenderer = GetComponent<MeshRenderer>;
        meshRenderer = GetComponent<MeshRenderer>();

    }
    private IEnumerator HeatCellCoroutine()
    { 
    yield return new WaitForSeconds(2);
        meshRenderer.material = heat1;
        state = 1;
        yield return new WaitForSeconds(2);
        meshRenderer.material = heat2;
        state = 2;
        yield return new WaitForSeconds(2);
        meshRenderer.material = heat3;
        state = 3;
    }
    private IEnumerator waitForSeconds(int damage)
    {
        HealthSystem.instance.TakeDamage(damage);
        yield return new WaitForSeconds(WaitForSeconds);
    }
 
    public void HeatCell()
    {
       // Debug.Log("Heat this cell!!");
        StartCoroutine(HeatCellCoroutine());
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
         //   Debug.Log("Fuck Hot!");

            switch (state)
            {
                case 0: break;
                case 1:
                    HealthSystem.instance.TakeDamage(1);
                    //StartCoroutine(waitForSeconds(1));
                    Debug.Log("Урон нанесен");
                    break;
                case 2:
                    HealthSystem.instance.TakeDamage(2);
                    // StartCoroutine(waitForSeconds(2));
                    Debug.Log("Урон нанесен");
                    break;
                case 3:
                    HealthSystem.instance.TakeDamage(10);
                    //  StartCoroutine(waitForSeconds(4));
                    Debug.Log("Урон нанесен");
                    break;

            }
        }
    }
    
}
 

