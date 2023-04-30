using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    float unDamageTime;
    float DamageTime;
    int damage;
    //public float lifeTime = 15f;
    private void Start()
    {
        damage = 5;
        Timer.instance.setHoldWin(false);
        unDamageTime = Timer.instance.getMaxTime();
       // Debug.Log(unDamageTime);
        DamageTime = HealthSystem.instance.GetMaxHealth();
        DamageTime = Timer.instance.getMaxTime() * damage;
       // Debug.Log(DamageTime);
        this.StartCoroutine("UnDamageMoment");
    }
    private void OnEnable()
    {

       
    }
    private void OnDisable()
    {
        this.StopAllCoroutines();
    }
    private IEnumerator UnDamageMoment()
    {
        yield return new WaitForSeconds(unDamageTime);
        StartCoroutine("DamageMoment");
    }
    private IEnumerator DamageMoment()
    {
        for(int i = 0; i < DamageTime; i++)
        {
            yield return new WaitForSeconds(1);
            HealthSystem.instance.TakeDamage(damage);
        }
    }
        
    
}
