using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [HideInInspector] DataSC dataCtr;
    string path;
    void Awake()
    {
        path = Application.persistentDataPath + "/data.json";
        dataCtr = GameObject.Find("GenMN").GetComponent<DataSC>();
    }
    private void Start()
    {
        //dataCtr.OnLoadMorpinos();
    }
    #region Handle Save JSON
    public void OnSavePlayer(int[] array)
    {
        PlayerData data = Load();
        data.playerDatas = array;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }
    public void OnReset()
    {
        PlayerData data = Load();
        int[] a = { -1, 0, 0, 0 };
        data.playerDatas = a;
    }
    #endregion
    public PlayerData Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.Log("No save file found");
            return new PlayerData();
        }
    }
}
