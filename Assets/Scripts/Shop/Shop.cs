using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataPlayerOperations : MonoBehaviour
{
   // public Shop.DataPlayer dataPlayer = new Shop.DataPlayer();
    //[HideInInspector]
    public string nameItem;
    public int priceItem;
    public GameObject[] allItem;
   //[SerializeField] Text balance;
    //public class DataPlayer
    //{
    //    public int money;
    //    public List<string> buyItem = new List<string>();
    //}
    private void Start()
    {
        if (PlayerPrefs.HasKey("SaveGame"))
        {
            LoadDataPlayer();


        }
        else {
            DataPlayer.instance.money = 500;
            SaveGame();
          //  balance.text = GetBalance().ToString();
            // LoadGame();
        }
       // balance.text = GetBalance().ToString();

    }
    private void SaveGame()
    {
        
     //   PlayerPrefs.SetString("SaveGame", JsonUtility.ToJson(dataPlayer));
        PlayerPrefs.SetString("SaveGame", JsonUtility.ToJson(DataPlayer.instance));
    }
    private void LoadDataPlayer()
    {
        DataPlayer.instance = JsonUtility.FromJson<DataPlayer>(PlayerPrefs.GetString("SaveGame"));
        //for (int i = 0; i < dataPlayer.buyItem.Count; i++)
        //{
        //    for (int y = 0; y < allItem.Length; y++)
        //    {
        //        if (allItem[y].GetComponent<Item>().nameItem == dataPlayer.buyItem[i])
        //        {
        //            allItem[y].GetComponent<Item>().TextItem.text = "Куплено";
        //            allItem[y].GetComponent<Item>().isBuy = true;

        //        }
        //    }
        //}
    }
    public int GetBalance()
    {
        return DataPlayer.instance.money;
    }
    public void BuyItem()
    {
        if (DataPlayer.instance.money >= priceItem)
        {
            DataPlayer.instance.buyItem.Add(nameItem);
            DataPlayer.instance.money = DataPlayer.instance.money - priceItem;
            SaveGame();
            //LoadDataPlayer();
        }
    }
}
