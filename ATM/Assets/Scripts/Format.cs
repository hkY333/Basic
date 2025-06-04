using TMPro;
using UnityEngine;

public class Format : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    void Start()
    {
        ulong num = ulong.Parse(text.text);
        text.text = num.ToString("N0");
    }
}
