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
        
        path = Path.Combine(Application.persistentDataPath, "Data.json");
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

    public string jID;
    public string jPassword;

    public void LoadUserData()
    {
        string json = File.ReadAllText(path);
        JToken root = JToken.Parse(json);

        jID = (string)root["id"];
        jPassword = (string)root["password"];
        JToken jName = root["name"];
        JToken jCash = root["cash"];
        JToken jBalance = root["balance"];

        myName.text = (string)jName;
        myCash.text = (string)jCash;
        myBalance.text = (string)jBalance;
    }

    public void Login()
    {
        GameManager.instance.path = Path.Combine(Application.persistentDataPath, $"{id.text}.json");
        LoadUserData();

        if (id.text == GameManager.instance.jID && password.text == GameManager.instance.jPassword)
        {
            Debug.Log("로그인 성공");
        }
        else
        {
            Debug.Log("해당 회원 미존재");
        }
        Refresh();
    }
}