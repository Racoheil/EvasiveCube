using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    public int cost;
    public int skinID;
    public bool isBought;
    public bool isSelected;

    public Button buyButton;
    public Button selectButton;
    public SkinsShop skinsShop;
    public PlayerBalance playerBalance;
    public Text selectBtnText;

    public void Buy()
    {
        if (cost <= playerBalance.balance)
        {
            playerBalance.balance -= cost;
            playerBalance.balanceText.text = playerBalance.balance.ToString();
            isBought = true;
            buyButton.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);
            PlayerPrefs.SetInt("balance", playerBalance.balance);
            PlayerPrefs.SetInt("buy" + skinID, 1);
            PlayerPrefs.Save();
        }
    }
    public void Select()
    {
        skinsShop.skins[skinsShop.activeSkinID].selectBtnText.text = "SELECT";
        skinsShop.skins[skinsShop.activeSkinID].isSelected = false;
        skinsShop.activeSkinID = skinID;
        isSelected = true;
        //selectButton.gameObject.SetActive(false);
        selectBtnText.text = "SELECTED";
        
        PlayerPrefs.SetInt("skinsID", skinID);
        PlayerPrefs.Save();
        
    }

}
