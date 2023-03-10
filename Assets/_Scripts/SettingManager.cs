using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public TextMeshProUGUI mode;
    public TextMeshProUGUI sound;
    public TextMeshProUGUI degree;
    public TextMeshProUGUI history;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("Degree", 0) == 0)
            degree.text = "简单";
        else degree.text = "困难";

        if (PlayerPrefs.GetInt("Mode", 0) == 0)
            mode.text = "普通模式";
        else mode.text = "多元模式";

        if (PlayerPrefs.GetInt("Sound", 1) == 0)
            sound.text = "关闭";
        else sound.text = "开启";

        history.text = "普通模式" + '\n' +
            "简单: " + PlayerPrefs.GetInt("History_normal_eazy", 0).ToString() + '\t' +
            "困难: " + PlayerPrefs.GetInt("History_normal_hard", 0).ToString() + '\n' +
            "多元模式" + '\n' +
            "简单: " + PlayerPrefs.GetInt("History_muti_eazy", 0).ToString() + '\t' +
            "困难: " + PlayerPrefs.GetInt("History_muti_hard", 0).ToString();
    }

    public void ChangeDegree()
    {
        if (PlayerPrefs.GetInt("Degree", 0) == 0)
        {
            degree.text = "困难";
            PlayerPrefs.SetInt("Degree", 1);
        }
        else
        {
            degree.text = "简单";
            PlayerPrefs.SetInt("Degree", 0);
        }
    }

    public void ChangeSound()
    {
        if (PlayerPrefs.GetInt("Sound", 0) == 0)
        {
            sound.text = "开启";
            PlayerPrefs.SetInt("Sound", 1);
        }
        else
        {
            sound.text = "关闭";
            PlayerPrefs.SetInt("Sound", 0);
        }
    }

    public void ChangeMode()
    {
        if (PlayerPrefs.GetInt("Mode", 0) == 0)
        {
            mode.text = "多元模式";
            PlayerPrefs.SetInt("Mode", 1);
        }
        else
        {
            mode.text = "普通模式";
            PlayerPrefs.SetInt("Mode", 0);
        }
    }
}
