using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObject : MonoBehaviour
{
    public sbyte objId;
    public sbyte objCategory;
    private Vector3 MousePos;
    public int dmgCur = 0;
    public int hpCur = 0; //current HP which increase or decrease in gameplay
    public int ammoCur = 0; //current ammo in amobox visible in gameplay;
    public int apCur = 0; //current AP visible in gameplay
    public float reloadAmmoSpdCur;
    public float reloadAPSpdCur;

    public int ammoMaxLoad;
    public int hpMaxLoad;
    public int apMaxLoad;

    [SerializeField] PBullet bullet;
    private int baseHP = 100;
    private int baseAmmoLoadout = 30;
    private int baseDamage = 1;
    private float baseReloadAmmoTime = 0.25f;
    private float baseReloadAPTime = 0.5f;
    private bool isReload;

    private int prefDamage; //Damage from PlayerPrefs
    private int prefHP; //Health from PlayerPrefs
    private int prefAmmo; //Ammo max load from PlayerPrefs
    private float prefRecharge; //Racharge max time from PlayerPrefs

    private int curCoin;
    private int prefTotalCoin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
