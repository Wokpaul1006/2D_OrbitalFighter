using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChornowormSC : EnemySC
{
    void Start()
    {
        SetUnitStat();
        base.Start();
    }
    void SetUnitStat()
    {
        moveSpd = 0.5f;
        atkSpd = 2;
        curHP = 1;
        selfScore = 2;
    }
}
