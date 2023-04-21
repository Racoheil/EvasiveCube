using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public class BombsGenerate2 : MonoBehaviour
{
    [SerializeField] private int poolCount =500;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] BombControl bombPrefab;
    public static BombsGenerate2 instance;
    [SerializeField] GameObject[] cells;
    [SerializeField] Vector3 bombPos;
    [SerializeField] GameObject Player;
    [SerializeField] int height = 10;
    public bool isGenerateBombs;
    [SerializeField] float spawnWait = 0.5f;
    [SerializeField] float spawnWait2 = 10f;

    [SerializeField] public List<Vector3> cellsPositions;
    [SerializeField] bool isChange;
    public float currentDrag;
    private PoolMono<BombControl> pool;

    void Awake()
    {
        currentDrag = 10;
        instance = this;
        fillList();

    }
    
    private void Start()
    {
        this.pool = new PoolMono<BombControl>(this.bombPrefab, this.poolCount, this.transform);
        this.pool.autoExpand = this.autoExpand;
        if (isGenerateBombs)
        {

            StartCoroutine(spawnBombCoroutine3());
          //  StartCoroutine(KillerBombCoroutine());
        }
    }
    public void RemoveCell(Vector3 cellPos)
    {
        cellsPositions.Remove(cellPos);
    }
    public void fillList()
    {

        for (int i = 0; i < cells.Length; i++)
        {
            cellsPositions.Add(cells[i].transform.position);

        }
    }
    IEnumerator spawnBombCoroutine3()
    {

        while (isGenerateBombs == true)
        {

            
           // Instantiate(bombPrefab, bombPos, Quaternion.identity);
            this.SpawnBomb();
            yield return new WaitForSeconds(spawnWait);

        }


    }
    IEnumerator KillerBombCoroutine()
    {

        while (isGenerateBombs == true)
        {

            
          
            this.KillerBombSpawn();
            yield return new WaitForSeconds(spawnWait2);

        }


    }
    private void SpawnBomb()
    {
        bombPos = cellsPositions[UnityEngine.Random.Range(0, cellsPositions.Count)];
      //  bombPos = cellsPositions[];
        bombPos.y = height;
       // bombPrefab.rb.drag = currentDrag;
        var bomb = this.pool.GetFreeElement();
        bomb.transform.position = bombPos;
        bomb.rb.drag = currentDrag;
    }
    private void KillerBombSpawn()
    {
        bombPos = Player.transform.position;
        bombPos.y = height;
        // bombPrefab.rb.drag = currentDrag;
        var bomb = this.pool.GetFreeElement();
        bomb.transform.position = bombPos;
        
   
    }
    public void reduceBombDrag(int value)
    {
       currentDrag -= value;
    }
}
