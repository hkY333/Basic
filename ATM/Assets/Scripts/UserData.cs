using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
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
