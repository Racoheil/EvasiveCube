using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public class BombsGenerate : MonoBehaviour
{
    
    public float  currentDrag ;
public static BombsGenerate instance;
    [SerializeField] BombControl bomb;
   
    [SerializeField] GameObject[] cells;
    
    [SerializeField] Vector3 bombPos;

    [SerializeField] int height = 10;
    public bool isGenerateBombs;
    [SerializeField] float spawnWait=0.5f;
   
    [SerializeField] public List<Vector3> cellsPositions;
    [SerializeField] bool isChange;

   
    public void fillList()
    {
        
        for(int i = 0; i < cells.Length; i++)
        {
            cellsPositions.Add(cells[i].transform.position);
            
        }
    }
   
    void Awake() {
        currentDrag = 10;
        instance = this;
        fillList();
        
    }
    void Start()
    {
        if (isGenerateBombs)
        {
        
            StartCoroutine(spawnBombCoroutine3());
        }
    }
   
    public void RemoveCell(Vector3 cellPos)
    {
        cellsPositions.Remove(cellPos);
    }

   
    IEnumerator spawnBombCoroutine3()
    {
      
        while (isGenerateBombs==true)
        {
            
            bombPos = cellsPositions[UnityEngine.Random.Range(0, cellsPositions.Count)];
            bombPos.y = height;
            bomb.rb.drag = currentDrag;
            Instantiate(bomb, bombPos, Quaternion.identity);
           
            yield return new WaitForSeconds(spawnWait);

        }


    }
   
}
