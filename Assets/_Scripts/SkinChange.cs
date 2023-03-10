using Doozy.Engine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinChange : MonoBehaviour
{
    public int id;
    public SkinManager sm;
    public TextMeshProUGUI price;

    public void ShowPricce(string x)
    {
        price.text = x;
    }
    public void Change()
    {
        if (id != 0 && PlayerPrefs.GetInt("Skin_" + id.ToString(), 0) == 0)
        {
            sm.messageImage.sprite = sm.skin[id].texture;
            sm.messageImage.color = sm.skin[id].color;
            sm.unlockID = id;
            sm.unlockImage = this.transform.GetChild(0).GetComponent<Image>();
            sm.UnlockPopup.Show(false);
        }
        else
        {
            sm.slt.enabled = false;
            sm.CurrentSkin = id;
            PlayerPrefs.SetInt("Skin", id);
            sm.slt = transform.GetChild(0).GetComponent<Image>();
            sm.slt.sprite = sm.select;
            sm.slt.enabled = true;
            sm.FreshSkin();
        }
    }
}
