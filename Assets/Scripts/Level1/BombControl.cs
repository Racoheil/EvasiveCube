using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControl : MonoBehaviour
{
    
    [SerializeField] CellControl cellControl;
    [SerializeField]static int damage = 1;
 
    
    

public Rigidbody rb;
   public bool isDestroyCell=true;
   
    void Start()
    {
        
       rb = GetComponent<Rigidbody>();
       
    }
   
  
    private void OnCollisionEnter(Collision collision)
    {

      
         if (collision.gameObject.tag == "Player")
        {
            HealthSystem.instance.TakeDamage(damage);
 
        }
        Deactivate();
        //Destroy(gameObject);
    }
   public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
