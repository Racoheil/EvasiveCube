using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBombsSpeed : MonoBehaviour
{
    void changeSpeed(int value)
    {
        BombsGenerate2.instance.currentDrag -= value;
    }
}
