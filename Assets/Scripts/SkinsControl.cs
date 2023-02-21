using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SkinsControl : MonoBehaviour
{
    public Text balance;
    public static bool isSkin1 = false;
    public static bool isSkin2 = false;
    public static bool isSkin3 = false;
    public Button skin1;
    public Button skin2;
    public Button skin3;
    public Button bSkin1;
    public Button bSkin2;
    public Button bSkin3;
    
    //public static int index
    //{
    //    get
    //    {
    //        return index;    // возвращаем значение свойства
    //    }
    //    set
    //    {
    //        index = value;   // устанавливаем новое значение свойства
    //    }
    //}

    public static SkinsControl instance;
   
    private void Awake()
    {

        instance = this;
    }



    private void Start()
    {
        if (isSkin1)
        {
            skin1.gameObject.SetActive(false);
            bSkin1.gameObject.SetActive(true);
        }
        if (isSkin2)
        {
            skin2.gameObject.SetActive(false);
            bSkin2.gameObject.SetActive(true);
        }
        if (isSkin3)
        {
            skin3.gameObject.SetActive(false);
            bSkin3.gameObject.SetActive(true);
        }
    }
    public void buySkin1()
    {
        if (PlayerBalance.instance.getBalance() >= 100) 
        {
            PlayerBalance.instance.topBalance(-100);
           
            skin1.gameObject.SetActive(false);
            bSkin1.gameObject.SetActive(true);
            isSkin1 = true;
            int newBalance = int.Parse(balance.text) - 100;
            balance.text = Convert.ToString(newBalance);
        }
    }
    public void buySkin2()
    {
        if (PlayerBalance.instance.getBalance() >= 100)
        {
            PlayerBalance.instance.topBalance(-100);
            skin2.gameObject.SetActive(false);
            bSkin2.gameObject.SetActive(true);
            isSkin2 = true;
            int newBalance = int.Parse(balance.text) - 100;
            balance.text = Convert.ToString(newBalance);
        }
    }
    public void buySkin3()
    {
        if (PlayerBalance.instance.getBalance() >= 100)
        {
            PlayerBalance.instance.topBalance(-100);
            skin3.gameObject.SetActive(false);
            bSkin3.gameObject.SetActive(true);
            isSkin3 = true;
            int newBalance = int.Parse(balance.text) - 100;
            balance.text = Convert.ToString(newBalance);
        }
    }
    public void chooseSkin1()
    {
        playerInfromation.indexOfSkin = 1;
    }
    public void chooseSkin2()
    {
        playerInfromation.indexOfSkin = 2;
    }
    public void chooseSkin3()
    {
        playerInfromation.indexOfSkin = 3;

    }
}
