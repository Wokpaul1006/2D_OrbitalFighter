using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharSetMN : MonoBehaviour
{
    [HideInInspector] DataSC dataCtr;
    [HideInInspector] OmniMN genCtr;
    [SerializeField] GameObject dialogPanel, charSetPanel, confirmPnl;
    [SerializeField] Text dialogTxt, confirmClassText;
    [SerializeField] Image imageConfirmToShow;
    [SerializeField] List<string> dialogList = new List<string>();
    [SerializeField] List<Sprite> classSprite =  new List<Sprite>();
    public int showOrder;
    public float step = 0.2f; // how much to move per click
    [SerializeField] ScrollRect inventoryScroll;
    private int dialougCount;
    private int orderClass;
    void Start()
    {
        genCtr = GameObject.Find("GeneralMN").GetComponent<OmniMN>();
        dataCtr = GameObject.Find("OBJ_DataCtr").GetComponent<DataSC>();

        dialogPanel.SetActive(true);
        charSetPanel.SetActive(false);
        confirmPnl.SetActive(false);

        dialougCount = 0;
        orderClass = -1;

        OnSetDialog();
        InvokeRepeating(nameof(OnShowDialog), 0f, 5f);
    }

    public void OnShowDialog()
    {
        dialougCount++;
        if (dialougCount < dialogList.Count)
        {
            dialogTxt.text = dialogList[dialougCount].ToString();
        }else if (dialougCount >= dialogList.Count)
        {
            CancelInvoke(nameof(OnShowDialog));
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
    public void OnChooseClass(int value)
    {
        orderClass = value;
        confirmPnl.gameObject.SetActive(true);
        switch (value)
        {
            case 0:
                confirmClassText.text = "Ultility";
                imageConfirmToShow.GetComponent<Image>().sprite = classSprite[0];
                break;
            case 1:
                confirmClassText.text = "Speeter";
                imageConfirmToShow.GetComponent<Image>().sprite = classSprite[1];
                break;
            case 2:
                confirmClassText.text = "Fighter";
                imageConfirmToShow.GetComponent<Image>().sprite = classSprite[2];
                break;
            case 3:
                confirmClassText.text = "Gladiator";
                imageConfirmToShow.GetComponent<Image>().sprite = classSprite[3];
                break;
            case 4:
                confirmClassText.text = "Interceptor";
                imageConfirmToShow.GetComponent<Image>().sprite = classSprite[4];
                break;
            case 5:
                confirmClassText.text = "Recon";
                imageConfirmToShow.GetComponent<Image>().sprite = classSprite[5];
                break;
            case 6:
                confirmClassText.text = "Medica";
                imageConfirmToShow.GetComponent<Image>().sprite = classSprite[6];
                break;
            case 7:
                confirmClassText.text = "Persue";
                imageConfirmToShow.GetComponent<Image>().sprite = classSprite[7];
                break;
            case 8:
                confirmClassText.text = "Glider";
                imageConfirmToShow.GetComponent<Image>().sprite = classSprite[8];
                break;
        }
    }
    public void OnSlideLeft() => inventoryScroll.horizontalNormalizedPosition = Mathf.Clamp01(inventoryScroll.horizontalNormalizedPosition + step);
    public void OnSlideRight() => inventoryScroll.horizontalNormalizedPosition = Mathf.Clamp01(inventoryScroll.horizontalNormalizedPosition - step);
    public void OnConfirmChooseClass()
    {
        dataCtr.UpdateFirsrtPlay();
        dataCtr.UpdatePlayerClass(orderClass);
        genCtr.OnChangeScene(0);
        dataCtr.LoadOldPlayer();
    }
}
