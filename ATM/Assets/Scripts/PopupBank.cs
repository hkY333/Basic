using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    [SerializeField] private GameObject depositBtn;
    [SerializeField] private GameObject withdrawBtn;
    [SerializeField] private GameObject depositUI;
    [SerializeField] private GameObject withdrawUI;
    [SerializeField] private GameObject attentionUI;
    [SerializeField] private GameObject warningUI;
    [SerializeField] private TMP_InputField customDeposit;
    [SerializeField] private TMP_InputField customWithdraw;

    public void OpenDepositUI()
    {
        depositBtn.SetActive(false);
        withdrawBtn.SetActive(false);
        depositUI.SetActive(true);
    }

    public void OpenWithdrawUI() 
    {
        depositBtn.SetActive(false);
        withdrawBtn.SetActive(false);
        withdrawUI.SetActive(true);
    }

    public void CloseDepositUI()
    {
        depositBtn.SetActive(true);
        withdrawBtn.SetActive(true);
        depositUI.SetActive(false);
    }

    public void CloseWithdrawUI()
    {
        depositBtn.SetActive(true);
        withdrawBtn.SetActive(true);
        withdrawUI.SetActive(false);
    }

    public void Deposit(int money)
    {
        string changeCash = GameManager.instance.myCash.text.Replace(",", "").Trim();
        string changeBalance = GameManager.instance.myBalance.text.Replace(",", "").Trim();

        int nowCash = int.Parse(changeCash);
        int nowBalance = int.Parse(changeBalance);

        if (nowCash - money >= 0)
        {
            nowCash -= money;
            nowBalance += money;
        }
        else
        {
            OpenAttentionUI();
        }

        GameManager.instance.myCash.text = nowCash.ToString();
        GameManager.instance.myBalance.text = nowBalance.ToString();
        GameManager.instance.userData.cash = (ulong)nowCash;
        GameManager.instance.userData.balance = (ulong)nowBalance;
    }

    public void Withdraw(int money)
    {
        string changeCash = GameManager.instance.myCash.text.Replace(",", "").Trim();
        string changeBalance = GameManager.instance.myBalance.text.Replace(",", "").Trim();

        int nowCash = int.Parse(changeCash);
        int nowBalance = int.Parse(changeBalance);

        if (nowBalance - money >= 0)
        {
            nowCash += money;
            nowBalance -= money;
        }
        else
        {
            OpenAttentionUI();
        }

        GameManager.instance.myCash.text = nowCash.ToString();
        GameManager.instance.myBalance.text = nowBalance.ToString();
        GameManager.instance.userData.cash = (ulong)nowCash;
        GameManager.instance.userData.balance = (ulong)nowBalance;
    }

    public void CustomDeposit()
    {
        if (customDeposit.text == "") OpenWarningUI();

        else
        {
            int nowCustom = int.Parse(customDeposit.text);

            if (nowCustom > 0)
            {
                Deposit(nowCustom);
            }

            else
            {
                OpenWarningUI();
            }

            customDeposit.text = null;
        }
    }

    public void CustomWithdraw()
    {
        if (customWithdraw.text == "") OpenWarningUI();

        else
        {
            int nowCustom = int.Parse(customWithdraw.text);
        
            if (nowCustom > 0)
            {
                Withdraw(nowCustom);
            }

            else
            {
                OpenWarningUI();
            }

            customWithdraw.text = null;
        }
    }

    public void OpenAttentionUI()
    {
        attentionUI?.SetActive(true);
    }

    public void CloseAttentionUI()
    {
        attentionUI?.SetActive(false);
    }

    public void OpenWarningUI()
    {
        warningUI?.SetActive(true);
    }

    public void CloseWarningUI()
    {
        warningUI?.SetActive(false);
    }
}
