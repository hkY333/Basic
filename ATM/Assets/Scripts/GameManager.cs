using System.IO;
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
        
        path = Path.Combine(Application.persistentDataPath, "Data.json");
    }

    void Start()
    {
        userData = new UserData("kyh", "2@" , "김영훈", 100000, 100000);
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
        string json = File.ReadAllText(path);
        JToken root = JToken.Parse(json);

        JToken jName = root["name"];
        JToken jCash = root["cash"];
        JToken jBalance = root["balance"];

        myName.text = (string)jName;
        myCash.text = (string)jCash;
        myBalance.text = (string)jBalance;
    }
}