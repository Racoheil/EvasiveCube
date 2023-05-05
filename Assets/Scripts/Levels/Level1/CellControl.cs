using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellControl : MonoBehaviour
{
    [SerializeField]int durability=4;
    [SerializeField] Material brokenCell,brokenCell2;
    MeshRenderer meshRenderer;
    
   
    void Start()
    {
        
         meshRenderer = GetComponent<MeshRenderer>();
    }
    public void hitCell( ){
        if (durability<0) {
           
       
            this.gameObject.SetActive(false);
          
        }
        else if(durability!=0)
        {
           
            durability--;
            meshRenderer.material = brokenCell;
        }
        else if (durability < 1)
        {
            durability--;
            meshRenderer.material = brokenCell2;
        }
     }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bomb")
        {

            hitCell();


        }
        else if (collision.gameObject.tag == "KillerBomb")
        {
            this.gameObject.SetActive(false);
        }


    }
}
