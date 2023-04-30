using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControl : MonoBehaviour
{
    
    [SerializeField] CellControl cellControl;
    [SerializeField] int damage = 1;
 
    
    

public Rigidbody rb;
   public bool isDestroyCell=true;
   
    void Start()
    {
        
       rb = GetComponent<Rigidbody>();
       
    }
   
  
    private void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Player":
                HealthSystem.instance.TakeDamage(damage);
                Deactivate();
              
            
                break;
            default:
                Deactivate();
                break;
        }
       

        
     
    }
   public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

}
