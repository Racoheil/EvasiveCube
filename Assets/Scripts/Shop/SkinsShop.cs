using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsShop : MonoBehaviour
{
    public int balance = 200;
    public Text balanceText;
    public Skin[] skins;
    public int activeSkinID = 0;
    public bool isDeleteAll;
    private void Start()
    {
        if (isDeleteAll) PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("balance"))
        {
            balance = PlayerPrefs.GetInt("balance");
        }
        if (PlayerPrefs.HasKey("skinsID"))
        {
            activeSkinID = PlayerPrefs.GetInt("skinsID");
        }
        skins[activeSkinID].isBought = true;
        //skins[activeSkinID].isSelected = true;
        skins[activeSkinID].selectBtnText.text = "SELECTED";
        PlayerPrefs.SetInt("buy" + activeSkinID, 1);
        PlayerPrefs.SetInt("scinsID", activeSkinID);

        balanceText.text = balance.ToString();
        for (int j = 0; j < skins.Length; j++)
        {

            if (PlayerPrefs.GetInt("buy" + j) == 1)
            {
                skins[j].isBought = true;
            }

            if (skins[j].isBought == true)
            {
                skins[j].buyButton.gameObject.SetActive(false);
                skins[j].selectButton.gameObject.SetActive(true);

            }

            if (skins[j].isSelected == true || skins[j].isBought == false)
            {
                skins[j].selectBtnText.text = "SELECT";
            }
        }
    }
}
