using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int maxHealth = 2;
    [SerializeField] int currentHealth;
    public static HealthSystem instance;
    public bool isArmor = false;
   [SerializeField] GameObject Protection;
    public int GetMaxHealth()
    {
        return maxHealth;
    }
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        HealthBar.instance.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        if (isArmor) 
        {
            return;
        }
        Debug.Log("Take damage biatch!! " + damage);
        currentHealth -= damage;
        HealthBar.instance.SetHealth(currentHealth);
        if (currentHealth < 1)
        {
            LoseWinManager.instance.playerLose();
            Debug.Log("Game OVER");
        }
       
    }
    public void Heal(int heal)
    {
        if (currentHealth< maxHealth)
        {
            currentHealth += heal;
            HealthBar.instance.SetHealth(currentHealth);
        }
    }
    public void activateArmor()
    {
        
        StartCoroutine(armorCoroutine(5));
        
    }
    IEnumerator armorCoroutine(int seconds)
    {
        Protection.SetActive(true);
        isArmor = true;
        yield return new WaitForSeconds(seconds);
        isArmor = false;
        Protection.SetActive(false) ;

    }
   
}
