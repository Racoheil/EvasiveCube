using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyControl : MonoBehaviour
{
    //[SerializeField]private float lifetime = 5f;
    //[SerializeField] PlayerBalance playerBalance;
    //private void OnEnable()
    //{
    //    this.StartCoroutine("LifeRoutine");
    //}
    //private void OnDisable()
    //{
    //    this.StopCoroutine("LifeRoutine");
    //}
    //private IEnumerator LifeRoutine()
    //{
    //    yield return new WaitForSecondsRealtime(this.lifetime);
    //    this.Deactivate();
    //}
    //private void Deactivate()
    //{
    //    this.gameObject.SetActive(false);
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("+1");
            PlayerBalance.instance.AddMoney(1);
            Deactivate();
        }
        
        //Destroy(gameObject);
    }
    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
 
}
