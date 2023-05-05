using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBalance : MonoBehaviour
{
    public static PlayerBalance instance;
    public int balance = 200;
    [SerializeField]public Text balanceText;
    
    private void Start()
    {


        if (PlayerPrefs.HasKey("balance"))
        {
            balance = PlayerPrefs.GetInt("balance");
        }
        balanceText.text = balance.ToString();
        TriggerEvents.singleton.moneyTakeEvent += AddMoney;
    }
    private void Awake()
    {
        instance = this;
    }
    public void SaveBalance(int money)
    {
        PlayerPrefs.SetInt("balance", money);
    }
    public void AddMoney()
    {
        balance += 1;
        balanceText.text = balance.ToString();
    }

}
