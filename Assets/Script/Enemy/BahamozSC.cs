using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BahamozSC : EnemySC
{

    void Start()
    {
        SetUnitStat();
        base.Start();
    }

    void SetUnitStat()
    {
        moveSpd = 1.5f;
        atkSpd = 2;
        curHP = 2;
        selfScore = 2;
    }
}
