using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControl : MonoBehaviour
{
    //[SerializeField] private float speed=0.1f;
    [SerializeField] CellControl cellControl;
    [SerializeField]static int damage = 1;
   // [SerializeField] BombsGenerate bombsGenerate;

    Rigidbody rb;
   public bool isDestroyCell=true;
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
       
      
    }
  
    private void OnCollisionEnter(Collision collision)
    {

        //if (collision.gameObject.tag == "Cell")
        //{

        //   // BombsGenerate.instance.RemoveCell(collision.gameObject);
        //   // Destroy(gameObject);
        //    //cellControl.hitCell(collision.gameObject);


        //}
      
         if (collision.gameObject.tag == "Player")
        {
            // Debug.Log("Game over");
            //playerMove.instance.playerLost();
          //  playerMove.instance.isCorrect = false;
           // Destroy(gameObject);
            HealthSystem.instance.TakeDamage(damage);
           // Destroy(gameObject);
           
        }
        
        Destroy(gameObject);
    }
   
}
