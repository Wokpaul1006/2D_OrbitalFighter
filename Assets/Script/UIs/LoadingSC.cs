using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSC : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] Slider progressBar;
    [SerializeField] OmniMN omniMN;

    [Header("Variables")]
    private float loadSpd;
    private void Start()
    {
        omniMN = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        progressBar.value = 0;
        StartCoroutine(RundLoad());
    }
    private IEnumerator RundLoad()
    {
        loadSpd = Random.Range(0.01f, 0.5f);
        if (progressBar.value >= 1)
        {
            omniMN.OnChangeScene(1);
        }
        yield return new WaitForSeconds(0.1f);
        progressBar.value += loadSpd * Time.deltaTime * 10;
        StartCoroutine(RundLoad());
    }
}
