using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UserData userData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Instance = GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        userData = new UserData("영훈", 100000, 50000);
    }
}
