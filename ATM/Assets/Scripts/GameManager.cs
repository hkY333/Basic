﻿using System.IO;
using TMPro;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UserData userData;
    [SerializeField] private Format cashFormat;
    [SerializeField] private Format balanceFormat;

    public TMP_InputField id;
    public TMP_InputField password;

    public TextMeshProUGUI myName;
    public TextMeshProUGUI myCash;
    public TextMeshProUGUI myBalance;

    public string path;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        instance = GetComponent<GameManager>();
    }

    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        myName.text = userData.name;
        myCash.text = userData.cash.ToString();
        myBalance.text = userData.balance.ToString();

        cashFormat.Formatting();
        balanceFormat.Formatting();
    }

    public void SaveUserData()
    {
        string json = JsonConvert.SerializeObject(userData, Formatting.Indented);
        File.WriteAllText(path, json);
    }

    public void LoadUserData()
    {
        path = Path.Combine(Application.persistentDataPath, $"{id.text}.json");

        string json = File.ReadAllText(path);
        JToken root = JToken.Parse(json);

        string jID = (string)root["id"];
        string jPassword = (string)root["password"];
        JToken jName = root["name"];
        JToken jCash = root["cash"];
        JToken jBalance = root["balance"];

        myName.text = (string)jName;
        myCash.text = (string)jCash;
        myBalance.text = (string)jBalance;

        userData.id = jID;
        userData.password = jPassword;
        userData.name = (string)jName;
        userData.cash = (ulong)jCash;
        userData.balance = (ulong)jBalance;
    }

    public void Login()
    {
        GameManager.instance.path = Path.Combine(Application.persistentDataPath, $"{id.text}.json");
        LoadUserData();
    }
}