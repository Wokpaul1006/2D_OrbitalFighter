using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharSetMN : MonoBehaviour
{
    [HideInInspector] DataSC dataCtr;
    [HideInInspector] GameObject dialogPanel, charSetPanel;
    [SerializeField] Text dialogTxt;
    [HideInInspector] List<string> dialogList = new List<string>();
    private int dialougCount;
    void Start()
    {
        dialogPanel.SetActive(true);
        charSetPanel.SetActive(false);

        dialougCount = 0;
        OnSetDialog();
        InvokeRepeating(nameof(OnShowDialog), 0f, 5f);
    }

    public void OnShowDialog()
    {
        dialougCount++;
        dialogTxt.text = dialogList[dialougCount].ToString();

        if (dialougCount == dialogList.Count)
        {
            OnShowChooseClass();
        }

    }
    private void OnSetDialog()
    {
        dialogList[0] = "Good day, Pilot";
        dialogList[1] = "Congratulate, you have graduated your trainning";
        dialogList[2] = "As your outstanding skill and effort, you have special offer that you can choose your own craft";
        dialogList[3] = "This is a special treatment from Institute and Emperor himself";
        dialogList[4] = "Now, show us what you want";
    }
    public void OnSkipDialog()
    {
        //Skip dialog
    }

    private void OnShowChooseClass()
    {
        dialogPanel.gameObject.SetActive(false);
        charSetPanel.SetActive(true);
    }
    public void OnConfirmChooseClass()
    {
        dataCtr.UpdateFirsrtPlay();
    }
}
