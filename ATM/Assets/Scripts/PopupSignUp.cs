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


    private void Awake()
    {
        if (uIController == null)
        {
            uIController = FindObjectOfType<UIController>();
        }
    }

    private void Start()
    {
        //password.contentType = TMP_InputField.ContentType.Alphanumeric;
        //password.lineType = TMP_InputField.LineType.SingleLine;
        //passwordConfirm.contentType = TMP_InputField.ContentType.Alphanumeric;
        //passwordConfirm.lineType = TMP_InputField.LineType.SingleLine;
    }

    private void OnEnable()
    {
        if (uIController == null)
        {
            //AddUserData 이벤트 등록
            uIController.OnSignUpComplete += AddUserData;
        }       
    }

    private void OnDisable()
    {
        if (uIController != null)
        {
            //AddUserData 이벤트 해제
            uIController.OnSignUpComplete -= AddUserData;
        }
    }

    private void AddUserData()
    {
        Debug.Log("AddUserData 실행");

        //새 userData 생성
        GameManager.instance.userData = new UserData($"{id.text}", $"{password.text}", $"{name.text}",
            100000, 100000);
        //해당 userData를 persistentDataPath로 경로 설정
        GameManager.instance.path = Path.Combine(Application.persistentDataPath, $"{name.text}.json");
        //json 파일 생성
        GameManager.instance.SaveUserData();
    }
}
