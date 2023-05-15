using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyEarn : MonoBehaviour
{
    [SerializeField] public Text pointsText;
    int points;
    public static MoneyEarn instance;
    private void Start()
    {
        
        points = 0;
        pointsText.text = points.ToString();
        TriggerEvents.singleton.moneyTakeEvent += AddPoint;
    }
    public void AddPoint()
    {
        points += 1;
        pointsText.text = points.ToString(); 
    }
    private void Awake()
    {
        instance = this;
    }
    public void topBalance()
    {
        PlayerBalance.instance.AddMoney(points);
    }
    public void hidePoints()
    {
        pointsText.gameObject.SetActive(false);
    }
}
