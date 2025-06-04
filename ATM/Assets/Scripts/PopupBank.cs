using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    [SerializeField] private GameObject depositBtn;
    [SerializeField] private GameObject withdrawalBtn;
    [SerializeField] private GameObject depositUI;
    [SerializeField] private GameObject withdrawalUI;

    public void OpenDepositUI()
    {
        depositBtn.SetActive(false);
        withdrawalBtn.SetActive(false);
        depositUI.SetActive(true);
    }

    public void OpenWithdrawalUI() 
    {
        depositBtn.SetActive(false);
        withdrawalBtn.SetActive(false);
        withdrawalUI.SetActive(true);
    }

    public void CloseDepositUI()
    {
        depositBtn.SetActive(true);
        withdrawalBtn.SetActive(true);
        depositUI.SetActive(false);
    }

    public void CloseWithdrawalUI()
    {
        depositBtn.SetActive(true);
        withdrawalBtn.SetActive(true);
        withdrawalUI.SetActive(false);
    }
}
