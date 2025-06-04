using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Data")]
public class UserDataSub : ScriptableObject
{
    public string name;
    public int cash;
    public int balance;
}
