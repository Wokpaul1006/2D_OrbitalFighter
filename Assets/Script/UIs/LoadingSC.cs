using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSC : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] Slider progressBar;
    [SerializeField] OmniMN omniMN;
    [SerializeField] DataSC dataSC;

    [Header("Variables")]
    public float target;
    private float loadSpd;
    private bool isFirstPlay;
    private void Awake()
    {
        dataSC = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();
    }
    private IEnumerator Start()
    {
        GetPlayerFirstPlay();
        loadSpd = Random.Range(0.1f, 1f);
        progressBar.value = 0;
        while (progressBar.value < target)
        {
            progressBar.value = Mathf.MoveTowards(progressBar.value, target, loadSpd * Time.deltaTime);
            yield return null;
        }
        if(isFirstPlay == true)
        {
            omniMN.OnChangeScene(5);
        }
        else omniMN.OnChangeScene(0);

    }
    private void GetPlayerFirstPlay()
    {
        if (dataSC.isFirstPlay == true)
        {
            print("in firstplay true");
            isFirstPlay = true;

        }
        else if(dataSC.isFirstPlay == false) {
            print("im first play false");
            isFirstPlay = false;
        }
    }
}
