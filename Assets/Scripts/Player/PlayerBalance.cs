using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBalance : MonoBehaviour
{
    [SerializeField]  static int Balance=100;
    [SerializeField] Text textBalance;
    public static PlayerBalance instance;
    public void topBalance(int sum) { Balance += sum; textBalance.text = $"{Balance}"; }
    public void reduceBalance(int sum) { Balance -= sum; textBalance.text = $"{Balance}"; }
    public int getBalance() { return Balance; }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        textBalance.text = $"{Balance}";
    }

}
