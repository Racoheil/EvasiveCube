using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public class BombsGenerate : MonoBehaviour
{
    
    public float  currentDrag ;
public static BombsGenerate instance;
    [SerializeField] BombControl bomb;
   //[SerializeField]GameObject[] cells2;
    [SerializeField] GameObject[] cells;
    //[SerializeField] List<GameObject> cells2 = new List<GameObject>();
    [SerializeField] Vector3 bombPos;
 //   [SerializeField] int[] randomOrder,randomOrder2;
    [SerializeField] static int height = 10;
    public bool isGenerateBombs;
    [SerializeField] float spawnWait=0.5f;
    // [SerializeField] bool isSpawnBombs;
    // Random randomNumber = new Random();
   
    [SerializeField] public List<Vector3> cellsPositions;
    [SerializeField] bool isChange;

    void Update()
    {
        
    }
    public void fillList(/*List<Vector3> CellPositions*/)
    {
        
        for(int i = 0; i < cells.Length; i++)
        {
            cellsPositions.Add(cells[i].transform.position);
            
        }
    }
    void changeDamage()
    {
        
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

    //public void createArray(int[] RandomOrder)
    //{
    //   // RandomOrder = new int[cells.Length];
    //    for (int i = 0; i < cells.Length; i++)
    //    {
    //        RandomOrder[i] = i;
    //      //  Debug.Log(randomOrder[i]);
    //    }
    //    //Debug.Log("''''''''");

    //    System.Random randomNumbers = new System.Random();
    //    for (int i = RandomOrder.Length - 1; i >= 1; i--)
    //    {
    //        int j = randomNumbers.Next(i + 1);

    //        int tmp = RandomOrder[j];
    //        RandomOrder[j] = RandomOrder[i];
    //        RandomOrder[i] = tmp;
    //    }
    //}
    //IEnumerator spawnBombCoroutine(int[] RandomOrder)
    //{
    //    int i = 0;
    //    while (i < cells.Length)
    //    {
    //        bombPos = cells[RandomOrder[i]].transform.position;
    //        bombPos.y = height;
    //        Instantiate(bomb, bombPos, Quaternion.identity);
    //        i++;
    //        yield return new WaitForSeconds(spawnWait);
            
    //    }
       

    //}

    //IEnumerator spawnBombCoroutine2()
    //{
    //    int i = 0;
    //    while (i < cells2.Count)
    //    {
    //        bombPos = cells2[UnityEngine.Random.Range(0, cells2.Count)].transform.position;
    //        bombPos.y = height;
    //        Instantiate(bomb, bombPos, Quaternion.identity);
    //        i++;
    //        yield return new WaitForSeconds(spawnWait);

    //    }


    //}
    IEnumerator spawnBombCoroutine3()
    {
        //int i = 0;
        while (isGenerateBombs==true)
        {
            if (cellsPositions.Count < 1)
            {
                isGenerateBombs = false;
                StopCoroutine(spawnBombCoroutine3());
            }
            bombPos = cellsPositions[UnityEngine.Random.Range(0, cellsPositions.Count)];

            bombPos.y = height;

            bomb.rb.drag = currentDrag;
            Instantiate(bomb, bombPos, Quaternion.identity);
            //Instantiate(bomb(currentDrag =4))
           // i++;
            yield return new WaitForSeconds(spawnWait);

        }


    }
   
}
