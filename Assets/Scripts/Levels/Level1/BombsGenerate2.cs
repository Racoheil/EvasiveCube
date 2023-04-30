using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public class BombsGenerate2 : MonoBehaviour
{
    [SerializeField] private int BombsPoolCount =500;
    [SerializeField] private int KBombsPoolCount = 12;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] BombControl bombPrefab;
    [SerializeField] BombControl KbombPrefab;
    public static BombsGenerate2 instance;
    [SerializeField] GameObject[] cells;
    [SerializeField] Vector3 bombPos;
    [SerializeField] GameObject Player;
    [SerializeField] int height = 10;
    public bool isGenerateBombs;
     float spawnWait = 0.5f;
    [SerializeField] float spawnWait2 = 10f;

   // [SerializeField] public List<Vector3> cellsPositions;
    [SerializeField] bool isChange;
    public float currentDrag;
    private PoolMono<BombControl> BombsPool;
    private PoolMono<BombControl> KBombsPool;
    public void addTimeBombsSpawn(float time) { spawnWait += time; }
    public float getSpawnWait() {return spawnWait; }
    void Awake()
    {
        currentDrag = 10;
        instance = this;
        //fillList();

    }
    
    private void Start()
    {
        this.BombsPool = new PoolMono<BombControl>(this.bombPrefab, this.BombsPoolCount, this.transform);
        this.KBombsPool = new PoolMono<BombControl>(this.KbombPrefab, this.KBombsPoolCount, this.transform);
        this.BombsPool.autoExpand = this.autoExpand;
        this.BombsPool.autoExpand = this.autoExpand;
        if (isGenerateBombs)
        {

            StartCoroutine(spawnBombCoroutine());
            StartCoroutine(KillerBombCoroutine());
        }
    }
    //public void RemoveCell(Vector3 cellPos)
    //{
    //    cellsPositions.Remove(cellPos);
    //}
    //public void fillList()
    //{

    //    for (int i = 0; i < cells.Length; i++)
    //    {
    //        cellsPositions.Add(cells[i].transform.position);

    //    }
    //}
    IEnumerator spawnBombCoroutine()
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

            
          
            
            yield return new WaitForSeconds(spawnWait2);
            this.KillerBombSpawn();
        }


    }
    private void SpawnBomb()
    {
       // bombPos = cellsPositions[UnityEngine.Random.Range(0, cellsPositions.Count)];
        bombPos = cells[UnityEngine.Random.Range(0, cells.Length)].transform.position;
      //  bombPos = cellsPositions[];
        bombPos.y = height;
       // bombPrefab.rb.drag = currentDrag;
        var bomb = this.BombsPool.GetFreeElement();
        bomb.transform.position = bombPos;
        bomb.rb.drag = currentDrag;
    }
    private void KillerBombSpawn()
    {
        bombPos = Player.transform.position;
        bombPos.y = height;
        // bombPrefab.rb.drag = currentDrag;
        var bomb = this.KBombsPool.GetFreeElement();
        bomb.transform.position = bombPos;
        
   
    }
    public void reduceBombDrag(int value)
    {
       currentDrag -= value;
    }
}
