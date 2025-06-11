using TMPro;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    [SerializeField] private UIController uIController;
    [SerializeField] private TMP_InputField customDeposit;
    [SerializeField] private TMP_InputField customWithdraw;

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
            uIController.OpenCheckMoneyUI();
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
            uIController.OpenCheckMoneyUI();
        }

        GameManager.instance.myCash.text = nowCash.ToString();
        GameManager.instance.myBalance.text = nowBalance.ToString();
        GameManager.instance.userData.cash = (ulong)nowCash;
        GameManager.instance.userData.balance = (ulong)nowBalance;
    }

    public void CustomDeposit()
    {
        if (customDeposit.text == "") uIController.OpenCheckCustomUI();

        else
        {
            int nowCustom = int.Parse(customDeposit.text);

            if (nowCustom > 0)
            {
                Deposit(nowCustom);
            }

            else
            {
                uIController.OpenCheckCustomUI();
            }

            customDeposit.text = null;
        }
    }

    public void CustomWithdraw()
    {
        if (customWithdraw.text == "") uIController.OpenCheckCustomUI();

        else
        {
            int nowCustom = int.Parse(customWithdraw.text);
        
            if (nowCustom > 0)
            {
                Withdraw(nowCustom);
            }

            else
            {
                uIController.OpenCheckCustomUI();
            }

                customWithdraw.text = null;
        }
    }
}
