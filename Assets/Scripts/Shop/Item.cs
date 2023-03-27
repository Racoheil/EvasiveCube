using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
   // public Shop scriptShop; 
    public string nameItem;
    public int priceItem;
    
    public Text TextItem;
    public bool isBuy;
    public void BuyItem()
    {
        if (isBuy == false)
        {
            //scriptShop.nameItem = nameItem;
            //scriptShop.priceItem = priceItem;
            //scriptShop.BuyItem();
        }
      
    }

}
