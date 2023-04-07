using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBalance : MonoBehaviour
{
    public int balance = 200;
    public Text balanceText;
    private void Start()
    {
        if (PlayerPrefs.HasKey("balance"))
        {
            balance = PlayerPrefs.GetInt("balance");
        }
        balanceText.text = balance.ToString();
    }


}
