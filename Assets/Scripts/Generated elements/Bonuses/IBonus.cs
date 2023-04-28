using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
   public float lifeTime=15f;
    private void OnEnable()
    {
        this.StartCoroutine("LifeRoutine");
    }
    private void OnDisable()
    {
        this.StopCoroutine("LifeRoutine");
    }
    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSeconds(lifeTime);
        this.Deactivate();
    }
    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

}
