using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    [SerializeField] private GameObject depositBtn;
    [SerializeField] private GameObject withdrawBtn;
    [SerializeField] private GameObject depositUI;
    [SerializeField] private GameObject withdrawUI;
    [SerializeField] private GameObject AttentionUI;

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

        nowCash -= money;
        nowBalance += money;

        GameManager.instance.myCash.text = nowCash.ToString();
        GameManager.instance.myBalance.text = nowBalance.ToString();
    }

    public void Withdraw(int money)
    {
        int nowCash = int.Parse(GameManager.instance.myCash.text);
        int nowBalance = int.Parse(GameManager.instance.myBalance.text);

        nowCash += money;
        nowBalance -= money;

        GameManager.instance.myCash.text = nowCash.ToString();
        GameManager.instance.myBalance.text = nowBalance.ToString();
    }

    public void OpenAttentionUI()
    {
        AttentionUI?.SetActive(true);
    }

    public void CloseAttentionUI()
    {
        AttentionUI?.SetActive(false);
    }
}
