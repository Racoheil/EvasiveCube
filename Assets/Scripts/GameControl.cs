using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject player;
    public int skinIndex = 0;
    public Material [] skins=new Material[3];
    public void SetIndex(int index) { skinIndex = index; }
    private void Awake()
    {

        instance = this;
    }
    public void GoToNextLevel()
    {
        SceneManager.LoadScene("Level2");
    }
    void Start()
    {
        skinIndex = playerInfromation.indexOfSkin;
        if (skinIndex != 0)
        {
            // Get the Mesh Renderer Component from this gameObject
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            // Get the current material applied on this GameObject
            Material oldMaterial = meshRenderer.material;
            //print the material name in the console
            Debug.Log("Applied Material: " + oldMaterial.name);
            // Set the new material on the GameObject
            meshRenderer.material = skins[skinIndex];
        }

    }
}
