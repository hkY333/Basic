using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject depositBtn;
    [SerializeField] private GameObject withdrawBtn;
    [SerializeField] private GameObject depositUI;
    [SerializeField] private GameObject withdrawUI;
    [SerializeField] private GameObject signUpUI;
    [SerializeField] private GameObject bankUI;
    [SerializeField] private GameObject logInUI;
    [SerializeField] private GameObject checkMoneyUI;
    [SerializeField] private GameObject checkCustomUI;
    [SerializeField] private GameObject checkInfoUI;
    [SerializeField] private GameObject completeSignUpUI;
    [SerializeField] private PopupSignUp popupSignUp;
    [SerializeField] private TextMeshProUGUI notice;

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

    public void OpenCheckMoneyUI()
    {
        checkMoneyUI?.SetActive(true);
    }

    public void CloseCheckMoneyUI()
    {
        checkMoneyUI?.SetActive(false);
    }

    public void OpenCheckCustomUI()
    {
        checkCustomUI?.SetActive(true);
    }

    public void CloseCheckCustomUI()
    {
        checkCustomUI?.SetActive(false);
    }

    public void OpenSignUpUI()
    {
        signUpUI?.SetActive(true);
    }

    public void CloseSignUpUI()
    {
        signUpUI?.SetActive(false);
    }

    public void OpenBankUI()
    {
        bankUI?.SetActive(true);
        logInUI?.SetActive(false);
    }

    public void OpenCheckInfoUI()
    {
        checkInfoUI?.SetActive(true);
    }

    public void CloseCheckInfoUI()
    {
        checkInfoUI?.SetActive(false);
    }

    public void OpenCompleteSignUpUI()
    {
        completeSignUpUI?.SetActive(true);
    }

    public void CloseCompleteSignUpUI()
    {
        completeSignUpUI?.SetActive(false);
        CloseSignUpUI();
    }

    public void CheckSignUp()
    {
        if (popupSignUp.id.text == "" || popupSignUp.name.text == "" ||
            popupSignUp.password.text == ""  || popupSignUp.passwordConfirm.text == "")
        {
            OpenCheckInfoUI();
            notice.text = "빈 칸이 존재합니다.";
        }

        else if (popupSignUp.password.text != popupSignUp.passwordConfirm.text)
        {
            OpenCheckInfoUI();
            notice.text = "비밀번호가 일치하지 않습니다.";
        }

        //else if (GameManager.instance.path )
        //{
        //    OpenCheckInfoUI();
        //    notice.text = "해당 아이디는 이미 사용중입니다.";
        //}

        else
        {
            OpenCompleteSignUpUI();
        }
    }
}
