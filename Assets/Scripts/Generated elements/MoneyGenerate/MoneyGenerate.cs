using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGenerate : MonoBehaviour
{
    [SerializeField] MoneyControl moneyPrefab;
    [SerializeField] int moneyPrefabsCount=7;

    [SerializeField] private int poolCount = 20;
    [SerializeField] GameObject[] cells;
   // [SerializeField] Vector3 moneyPos;
    [SerializeField] float spawnWait = 5f;
    [SerializeField] public List<Vector3> cellsPositions;
    private PoolMono<MoneyControl> pool;
    private bool isGenerateMoney=true;
    [SerializeField] private bool autoExpand = true;
    float height;
    void Awake()
    {
       
        fillList();

    }
    private void Start()
    {
        height = cellsPositions[0].y + 0.5f;
        this.pool = new PoolMono<MoneyControl>(this.moneyPrefab, this.poolCount, this.transform);
         this.pool.autoExpand = this.autoExpand;
        

            StartCoroutine(spawnMoneyCoroutine());
       

    }
    public void fillList()
    {

        for (int i = 0; i < cells.Length; i++)
        {
            //cellsPositions.Add(cells[i].transform.position);

        }
    }
    IEnumerator spawnMoneyCoroutine()
    {

        while (isGenerateMoney == true)
        {

         for(int i = 0; i < moneyPrefabsCount; i++)
            {
                this.spawnMoney();
            }
            
            yield return new WaitForSecondsRealtime(spawnWait);

        }


    }
    private void spawnMoney()
    {
        int numberOfCell = UnityEngine.Random.Range(0, cells.Length);
      
        if (cells[numberOfCell].gameObject.activeSelf == true)
        {
            
           Vector3 moneyPos = new Vector3(cells[numberOfCell].transform.position.x, 
               height, cells[numberOfCell].transform.position.z);
          //  moneyPos.y = height;
            var money = this.pool.GetFreeElement();
            money.transform.position = moneyPos;
        }
        else Debug.Log("ти далбаеб клетка уништожена");
    }
}
