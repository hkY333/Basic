using Newtonsoft.Json.Linq;
using System;
using System.IO;
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
    [SerializeField] private GameObject checkLoginInfoUI;

    // 이벤트 선언: 회원가입 성공 시 호출
    public event Action OnSignUpComplete;

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
        string path = Path.Combine(Application.persistentDataPath, $"{GameManager.instance.id.text}.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            JToken root = JToken.Parse(json);

            if (GameManager.instance.id.text == "" || GameManager.instance.password.text == "")
            {
                OpenCheckLoginInfoUI();
                Debug.Log("빈칸 입력");
            }

            else if (GameManager.instance.password.text != (string)root["password"])
            {
                OpenCheckLoginInfoUI();
                Debug.Log("password 틀림");
            }

            else
            {
                bankUI?.SetActive(true);
                logInUI?.SetActive(false);
                GameManager.instance.Login();
            }
        }

        else
        {
            OpenCheckLoginInfoUI();
            Debug.Log("회원 없음");
        }
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
        string path = Path.Combine(Application.persistentDataPath, $"{popupSignUp.id.text}.json");

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

        else if (File.Exists(path))
            {
                OpenCheckInfoUI();
                notice.text = "해당 아이디는 이미 사용중입니다.";
            }

        else
        {
            OpenCompleteSignUpUI();
            //이벤트 전달
            OnSignUpComplete?.Invoke();
            //빈 칸으로 만들기
            popupSignUp.id.text = popupSignUp.name.text = popupSignUp.password.text =
                popupSignUp.passwordConfirm.text = notice.text = "";
        }
    }

    public void OpenCheckLoginInfoUI()
    {
        checkLoginInfoUI?.SetActive(true);
    }

    public void CloseCheckLoginInfoUI()
    {
        checkLoginInfoUI?.SetActive(false);
    }
}
