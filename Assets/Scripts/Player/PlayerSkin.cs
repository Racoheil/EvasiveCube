using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    //private SpriteRenderer spriteRenderer;
  //  public Sprite[] scins;
    public Material[] skins = new Material[3];
    private void Start()
    {
        int skinsID = PlayerPrefs.GetInt("skinsID");
      
            // Get the Mesh Renderer Component from this gameObject
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            // Get the current material applied on this GameObject
            
            // Set the new material on the GameObject
            meshRenderer.material = skins[skinsID];
        
        

    }


}
