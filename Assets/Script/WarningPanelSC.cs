using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WarningPanelSC : MonoBehaviour
{
    [SerializeField] Text nameTxt, contentTxt;
    void Start()
    {          }
    void Update()
    {          }
    public void ShowContent(int callRoot, int contentOrder)
    {
        switch (callRoot)
        {
            case 1:
                nameTxt.text = "NOTICE!";
                break;
            case 2:
                nameTxt.text = "WARNING";
                break;
            case 3:
                nameTxt.text = "ANNOUCMENT";
                break;
        }
        switch (contentOrder)
        {
            case 1:
                contentTxt.text = "ALREADY HAVE ATTACHMENT";
                break;
            case 2:
                contentTxt.text = "INSUFFICIENT FUND";
                break;
            case 3:
                contentTxt.text = "ATTACHMENT BUY COMPLETE. JOIN BATTLE TO SEE EFFECTIVE";
                break;
        }
    }
}
