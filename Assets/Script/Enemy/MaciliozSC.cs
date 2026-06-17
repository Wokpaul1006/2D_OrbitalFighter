using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaciliozSC : EnemySC
{  
    void Start()
    {
        SetUnitStat();
        base.Start();
    }
    void SetUnitStat()
    {
        moveSpd = 3;
        atkSpd = 1;
        curHP = 6;
        selfScore = 2;
    }
}
