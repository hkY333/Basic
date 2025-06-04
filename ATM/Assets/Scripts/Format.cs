using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Format : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private int num;

    // Start is called before the first frame update
    void Start()
    {
        text.text = num.ToString("#,###");
        //text.text = string.Format("{0:#,###}", text.text);
    }
}
