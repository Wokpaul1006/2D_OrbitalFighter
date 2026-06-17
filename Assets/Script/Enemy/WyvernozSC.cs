using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WyvernozSC : EnemySC
{
    void Start()
    {
        base.Start();
        SetUnitStat();
    }
    void SetUnitStat()
    {
        moveSpd = 1f;
        atkSpd = 2;
        curHP = 3;
        selfScore = 2;
    }
}
