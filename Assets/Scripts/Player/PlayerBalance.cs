using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBalance : MonoBehaviour
{
    public static PlayerBalance instance;
    public int balance ;
    [SerializeField]public Text balanceText;
    
    private void Start()
    {


        if (PlayerPrefs.HasKey("balance"))
        {
            balance = PlayerPrefs.GetInt("balance");
        }
        else balance = 200;
        balanceText.text = balance.ToString();
        //if(SceneManager.GetActiveScene().name!="MainMenu") TriggerEvents.singleton.moneyTakeEvent += AddMoney;

    }
    private void Awake()
    {
        instance = this;
    }
    public void SaveBalance(int money)
    {
        PlayerPrefs.SetInt("balance", money);
    }
    public void AddMoney(int money)
    {
        balance += money;
        balanceText.text = balance.ToString();
    }
   
   public void showBalance()
    {
        balanceText.gameObject.SetActive(true);
    }

    internal void SaveBalance()
    {
        PlayerPrefs.SetInt("balance", balance);
    }
}
