using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBalance : MonoBehaviour
{
    [SerializeField] public static int Balance=0;
    [SerializeField] Text textBalance;
    public static PlayerBalance instance;
    public void topBalance(int sum) { Balance += sum; }
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
