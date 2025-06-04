using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UserData userData;
    [SerializeField] private Format cashFormat;
    [SerializeField] private Format balanceFormat;

    public TextMeshProUGUI myName;
    public TextMeshProUGUI myCash;
    public TextMeshProUGUI myBalance;

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
        userData = new UserData("김영훈", 100000, 500000);
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
}