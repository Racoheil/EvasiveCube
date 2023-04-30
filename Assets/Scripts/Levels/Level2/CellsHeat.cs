using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsHeat : MonoBehaviour
{
    [SerializeField] GameObject[] heatingCells;
   // [SerializeField] HeatCellControl[] heatCellControl;
    [SerializeField]public bool isHeat;
  //  GameObject[] heatCells;
    public float waitTime=1;
    public static CellsHeat instance;
    void Start()
    {
      //  Debug.Log("Start!");
        StartCoroutine(HeatCells());
    }
    private void Awake()
    {
        instance = this;
    }
    public IEnumerator HeatCells()
    {
        while (isHeat==true)
        {
            heatingCells[UnityEngine.Random.Range(0, heatingCells.Length)].SendMessage("HeatCell");
            heatingCells[UnityEngine.Random.Range(0, heatingCells.Length)].SendMessage("HeatCell");
            yield return new WaitForSeconds(waitTime);
        }
    }
    public IEnumerator HeatPlayer()
    {
        while (isHeat == true)
        {
            heatingCells[UnityEngine.Random.Range(0, heatingCells.Length)].SendMessage("HeatCell");
            heatingCells[UnityEngine.Random.Range(0, heatingCells.Length)].SendMessage("HeatCell");
            yield return new WaitForSeconds(waitTime);
        }
    }
    public void addWaitTime(float value)
    {
        waitTime += value;
    }
}
