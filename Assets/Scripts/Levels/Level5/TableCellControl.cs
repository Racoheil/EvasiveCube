using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCellControl : MonoBehaviour
{
    MeshRenderer meshRenderer;
    [SerializeField] Material cuttedCell;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Knife")
        {
            Debug.Log("Воткунлся");
            meshRenderer.material = cuttedCell;
        }
    }
}
