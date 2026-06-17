using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MopivernSC : EnemySC
{
    void Start()
    {
        SetUnitStat();
        base.Start();
    }
    void SetUnitStat()
    {
        moveSpd = 4f;
        atkSpd = 1;
        curHP = 5;
        selfScore = 3;
    }
}
