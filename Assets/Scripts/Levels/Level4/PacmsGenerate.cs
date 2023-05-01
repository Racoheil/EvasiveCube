using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmsGenerate : MonoBehaviour
{
    [SerializeField] GameObject startCell;
    int PacmsCount=9;
  //  GameObject pacmObject;
    [SerializeField] PacmControl pacmPrefab;
    Vector3 pacmPos;
    float additionalHeight = 0.8f;
    float moveStep = 1.3f;
    private PoolMono<PacmControl> PacmsPool;

    private void Start()
    {
        pacmPos = startCell.transform.position;
        pacmPos.y += additionalHeight;
        this.PacmsPool = new PoolMono<PacmControl>(this.pacmPrefab, this.PacmsCount, this.transform);
        StartCoroutine("spawnPacmsCoroutine");
    }
    IEnumerator spawnPacmsCoroutine()
    {

        for (int i = 0; i < PacmsCount; i++)
        {


            Debug.Log("Spawn");
            int spawnWait = UnityEngine.Random.Range(0, 6);
            PacmSpawn(i);
            yield return new WaitForSecondsRealtime(spawnWait);
            
          


        }
    }
     void PacmSpawn(int num)
    {
        var pacm = this.PacmsPool.GetFreeElement();
        if (num != 0)
        {
            pacmPos = new Vector3(pacmPos.x, pacmPos.y, pacmPos.z - moveStep);
        pacm.transform.position = pacmPos;

        }
        else
        {
            pacm.transform.position = pacmPos;
        }
    }
}
