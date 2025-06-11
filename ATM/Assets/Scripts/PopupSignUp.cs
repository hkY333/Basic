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
        }
    }

    private void OnEnable()
    {
        if (uIController == null)
        {
            //Debug.LogError("UIController가 null입니다! 인스펙터에서 올바르게 참조되었는지 확인하세요.");
        }
        else
        {
            uIController.OnSignUpComplete += AddUserData;
            Debug.Log("AddUserData 등록");
        }

    }

    private void OnDisable()
    {
        if (uIController == null)
        {
            //Debug.LogError("UIController가 null입니다! 인스펙터에서 올바르게 참조되었는지 확인하세요.");
        }
        else
        {
            uIController.OnSignUpComplete -= AddUserData;
            Debug.Log("AddUserData 해제");
        }

    }

    private void AddUserData()
    {
        Debug.Log("AddUserData 실행");

        //새 userData 생성
        GameManager.instance.userData = new UserData($"{id.text}", $"{name.text}", $"{password.text}",
            100000, 100000);
        //해당 userData를 persistentDataPath로 경로 설정
        GameManager.instance.path = Path.Combine(Application.persistentDataPath, $"{name.text}.json");
        //json 파일 생성
        GameManager.instance.SaveUserData();
    }
}
