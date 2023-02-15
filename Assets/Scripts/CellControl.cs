using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellControl : MonoBehaviour
{
    [SerializeField]int durability=2;
    [SerializeField] Material brokenCell;
    MeshRenderer meshRenderer;
    [SerializeField] int solid=5;
   // int hp;
    void Start()
    {
        // hp = 2;
         meshRenderer = GetComponent<MeshRenderer>();
    }
    public void hitCell( ){
        if (durability<solid) {
           
         Destroy(gameObject); 
           // Debug.Log("Cell is destroyed");
            BombsGenerate.instance.RemoveCell(this.gameObject.transform.position);
        }
        else
        {
           
            durability--;
            meshRenderer.material = brokenCell;
        }
     }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bomb")
        {

            hitCell();
            //cellControl.hitCell();


        }


    }
}
