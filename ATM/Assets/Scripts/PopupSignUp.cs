using System;
using System.IO;
using TMPro;
using UnityEngine;

public class PopupSignUp : MonoBehaviour
{
    public UIController uIController;

    public TMP_InputField id;
    public TMP_InputField name;
    public TMP_InputField password;
    public TMP_InputField passwordConfirm;


    void Awake()
    {
        if (uIController == null)
        {
            uIController = FindObjectOfType<UIController>();
            if (uIController == null)
            {
                Debug.LogError("UIController를 찾을 수 없습니다! 씬에 존재하는지 확인하세요.");
            }
        }
        else
        {
            Debug.Log("UI컨트롤러 존재");
        }
    }

    private void OnEnable()
    {
        if (uIController == null)
        {
            Debug.LogError("UIController가 null입니다! 인스펙터에서 올바르게 참조되었는지 확인하세요.");
        }
        else
        {
            uIController.OnSignUpComplete += AddUserData;
            Debug.Log("AddUserData 실행");
        }

    }

    private void OnDisable()
    {
        if (uIController == null)
        {
            Debug.LogError("UIController가 null입니다! 인스펙터에서 올바르게 참조되었는지 확인하세요.");
        }
        else
        {
            uIController.OnSignUpComplete -= AddUserData;
            Debug.Log("AddUserData 삭제");
        }

    }

    private void AddUserData()
    {
        //새 userData 생성
        GameManager.instance.userData = new UserData($"{id.text}", $"{name.text}", $"{password.text}",
            100000, 100000);
        //해당 userData를 json 파일로 생성
        GameManager.instance.path = Path.Combine(Application.persistentDataPath, $"{name.text}.json");
    }
}
