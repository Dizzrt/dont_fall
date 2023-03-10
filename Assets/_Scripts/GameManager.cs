using Doozy.Engine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData gd;
    public PlayerController pc;

    [Header("First Game Tips")]
    public UIPopup FirstIn;
    public UIPopup FirstNormal;
    public UIPopup FirstMuti;

    public void Initialized()
    {
        pc.AddScore();

        gd.degree = PlayerPrefs.GetInt("Degree");
        gd.GameMode = PlayerPrefs.GetInt("Mode");

        if (gd.degree == 0)
        {
            gd.Data = gd.Eazy;
            pc.ani.Play("PEazy");
        }
        else
        {
            gd.Data = gd.Hard;
            pc.ani.Play("PHard");
        }
        pc.CheckDistance = gd.Data.CheckDistance;
        gd.Data.CurrentSpeed = gd.Data.BeginSpeed;
        gd.Data.SpawnTimeDelta = gd.Data.BeginTimeDelta;

        gd.Default.SetActive(false);
        gd.GamingShow.SetActive(true);

        gd.Gaming = true;

        //game guide
        //if (gd.GameMode == 0)
        //    CheckFirstNormal();
        //else CheckFirstMuti();
    }
    public void Awake()
    {
        CheckFirstIn();
    }
    private void Update()
    {
        if (!gd.Gaming)
            return;

        if (Time.time - gd.Data.LastSpawnTime >= gd.Data.SpawnTimeDelta)
        {
            while (gd.Data.CurrentSpawnPoint == gd.Data.LastSpawnPoint)
                gd.Data.CurrentSpawnPoint = Random.Range(0, 3);

            if (gd.GameMode == 1)
                gd.BarID = Random.Range(0, 4);
            Instantiate(gd.Bar[gd.BarID], gd.SpawnPoint[gd.Data.CurrentSpawnPoint].position, Quaternion.Euler(0, 0, Random.Range(gd.Data.AngleLimit.x, gd.Data.AngleLimit.y)), gd.Index);

            gd.Data.LastSpawnTime = Time.time;
            gd.Data.LastSpawnPoint = gd.Data.CurrentSpawnPoint;
        }
    }

    public void recover()
    {
        for (int i = 0; i < this.gameObject.GetComponent<SkinManager>().skin.Length; i++)
            PlayerPrefs.SetInt("Skin_" + i.ToString(), 0);
        PlayerPrefs.SetInt("Money", 0);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("History_normal_eazy", 0);
        PlayerPrefs.SetInt("History_normal_hard", 0);
        PlayerPrefs.SetInt("History_muti_eazy", 0);
        PlayerPrefs.SetInt("History_muti_hard", 0);
        PlayerPrefs.SetInt("Skin", 0);
        PlayerPrefs.SetInt("FirstIn", 1);
        PlayerPrefs.SetInt("FirstMuti", 1);
        PlayerPrefs.SetInt("FirstNormal", 1);
    }

    private void CheckFirstIn()
    {
        if (PlayerPrefs.GetInt("FirstIn", 1) == 1)
        {
            FirstIn.Show(false);
            PlayerPrefs.SetInt("FirstIn", 0);
        }
        else return;
    }

    //private void CheckFirstNormal()
    //{
    //    if (PlayerPrefs.GetInt("FirstNormal", 1) == 1)
    //    {
    //        FirstNormal.Show(false);
    //        PlayerPrefs.SetInt("FirstNormal", 0);
    //    }
    //    else return;
    //}

    //private void CheckFirstMuti()
    //{

    //    if (PlayerPrefs.GetInt("FirstMuti", 1) == 1)
    //    {
    //        FirstMuti.Show(false);
    //        PlayerPrefs.SetInt("FirstMuti", 0);
    //    }
    //    else return;
    //}

    public void TimeSwitch()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}
