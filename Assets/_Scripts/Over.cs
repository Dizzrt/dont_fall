using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Over : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI history;
    public TextMeshProUGUI money;
    public TextMeshProUGUI message;

    public string[] Message;
    public string[] Message_New;

    private void Awake()
    {
        score.text = PlayerPrefs.GetInt("Score", 0).ToString();

        history.text = "普通模式" + '\n' +
            "简单: " + PlayerPrefs.GetInt("History_normal_eazy", 0).ToString() + '\t' +
            "困难: " + PlayerPrefs.GetInt("History_normal_hard", 0).ToString() + '\n' +
            "多元模式" + '\n' +
            "简单: " + PlayerPrefs.GetInt("History_muti_eazy", 0).ToString() + '\t' +
            "困难: " + PlayerPrefs.GetInt("History_muti_hard", 0).ToString();

        money.text = PlayerPrefs.GetInt("Money", 0).ToString();

        if (PlayerPrefs.GetInt("NewRecord", 0) == 1)
        {
            message.text = Message_New[Random.Range(0, Message_New.Length)];
            PlayerPrefs.SetInt("NewRecord", 0);
        }
        else message.text = Message[Random.Range(0, Message.Length)];
    }
}
