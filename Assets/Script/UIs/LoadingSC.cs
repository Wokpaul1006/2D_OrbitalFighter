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

    [Header("Variables")]
    public float target;
    private float loadSpd;
    private void Awake()
    {
        GetPlayerInfors();
    }
    private IEnumerator Start()
    {
        loadSpd = Random.Range(0.1f, 1f);
        progressBar.value = 0;
        while (progressBar.value < target)
        {
            progressBar.value = Mathf.MoveTowards(progressBar.value, target, loadSpd * Time.deltaTime);
            yield return null;
        }
        omniMN.OnChangeScene(0);
    }
    private void GetPlayerInfors()
    {

    }
}
