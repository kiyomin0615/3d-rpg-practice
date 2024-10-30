using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    int score = 0;

    public void OnButtonClicked()
    {
        score++;
        text.text = $"SCORE : {score}";
    }
}
