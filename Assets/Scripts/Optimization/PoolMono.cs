using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    public T prefab { get; }
    public bool autoExpand { get; set; } // Авторасширение, создание объекта если не хватает
    public Transform container { get; }// для объектов
    private List<T> pool;//где будут храниться ссылки на созданные объекты
    public PoolMono(T prefab, int count)
    {
        this.prefab = prefab;
        this.container = null;

        this.CreatePool(count);
    }
    public PoolMono(T prefab, int count,Transform container)
    {
        this.prefab = prefab;
        this.container = container;
        this.CreatePool(count);
    }
    private void CreatePool(int count)
    {
        this.pool = new List<T>();
        for(int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }
    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(this.prefab, this.container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        this.pool.Add(createdObject);
        return createdObject;
    }
    public bool HasFreeElement(out T element)
    {
        foreach(var mono in pool){
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;

    }
    public T GetFreeElement()
    {
        if(this.HasFreeElement(out var element))
        {
            return element;
        }
        if (this.autoExpand) return this.CreateObject(isActiveByDefault: true);
        throw new System.Exception(message: $"There is no free elements in pool of type {typeof(T)}");
    }
}
