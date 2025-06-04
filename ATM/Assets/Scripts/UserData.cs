using UnityEngine;

[System.Serializable]
public class UserData
{
    public string name;
    public int cash;
    public int balance;

    public UserData(string newName, int newCash, int newBalance)
    {
        name = newName;
        cash = newCash;
        balance = newBalance;
    }
}
