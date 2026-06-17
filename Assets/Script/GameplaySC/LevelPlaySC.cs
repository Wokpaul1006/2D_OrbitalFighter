using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlaySC : MonoBehaviour
{
    [SerializeField] List<SpawnerSC> spawnerList = new List<SpawnerSC>();
    [SerializeField] List<GameObject> defendList = new List<GameObject>();

    private int curLevel;
    private int pHP; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
