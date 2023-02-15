using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsHeat : MonoBehaviour
{
    [SerializeField] GameObject[] heatingCells;
    [SerializeField] HeatCellControl[] heatCellControl;
    [SerializeField]bool isHeat;
    GameObject[] heatCells;
    public float waitTime=1;
    void Start()
    {
      //  Debug.Log("Start!");
        StartCoroutine(HeatCells());
    }
    
    public IEnumerator HeatCells()
    {
        while (isHeat==true)
        {
           // Debug.Log("HEat@");
            //heatingCells.
            //heatingCells[].
            //  bombPos = cellsPositions[UnityEngine.Random.Range(0, cellsPositions.Count)];
            heatingCells[UnityEngine.Random.Range(0, heatingCells.Length)].SendMessage("HeatCell");
            heatingCells[UnityEngine.Random.Range(0, heatingCells.Length)].SendMessage("HeatCell");

            //  heatCellControl[UnityEngine.Random.Range(0, heatingCells.Length)].HeatCell();

            yield return new WaitForSeconds(waitTime);
        }
    }
}
