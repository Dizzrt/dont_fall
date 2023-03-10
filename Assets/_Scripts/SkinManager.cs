using Doozy.Engine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    [Header("Unlock Skin")]
    public int unlockID;
    public UIPopup UnlockPopup;
    public UIPopup WrongPopup;
    public Image unlockImage;
    public Image messageImage;
    [Header("Common Sprite")]
    public Image slt;
    public Sprite select;
    public Sprite locked;
    [Header("Base")]
    public int CurrentSkin;
    public Image iskin;
    public RectTransform content;
    public Button ins_templete;

    private float height = 300;
    private float up = -150;
    private float[] left = { -340, 0, 340 };
    [System.Serializable]
    public class Skin
    {
        public int price;
        public string ShowPrice;
        public Sprite texture;
        public Color color;
    }
    public Skin[] skin;

    public void FreshSkin()
    {
        CurrentSkin = PlayerPrefs.GetInt("Skin", 0);
        iskin.sprite = skin[CurrentSkin].texture;
        iskin.color = skin[CurrentSkin].color;
    }
    private void Awake()
    {
        FreshSkin();

        for (int i = 0; i < skin.Length; i++)
        {
            if (i % 3 == 0 && i != 0)
            {
                up -= 300;
                height += 300;
            }

            Button temp = Instantiate(ins_templete, content);
            temp.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(left[i % 3], up);
            temp.GetComponent<Image>().sprite = skin[i].texture;
            temp.GetComponent<Image>().color = skin[i].color;

            SkinChange s_temp = temp.GetComponent<SkinChange>();
            s_temp.id = i;
            s_temp.sm = this;
            s_temp.ShowPricce(skin[i].ShowPrice);

            Image itemp = temp.transform.GetChild(0).GetComponent<Image>();
            if (CurrentSkin == i)
            {
                itemp.sprite = select;
                slt = itemp;
            }
            else if (PlayerPrefs.GetInt("Skin_" + i.ToString(), 0) == 0 && i > 0)
                itemp.sprite = locked;
            else itemp.enabled = false;
        }

        content.sizeDelta = new Vector2(1080, height > 1350 ? height : 0);
    }

    public void Unlock()
    {
        int temp = PlayerPrefs.GetInt("Money", 0);
        if (temp >= skin[unlockID].price)
        {
            PlayerPrefs.SetInt("Skin_" + unlockID.ToString(), 1);
            PlayerPrefs.SetInt("Money", temp - skin[unlockID].price);
            unlockImage.enabled = false;
            UnlockPopup.Hide(false);
        }
        else
        {
            UnlockPopup.Hide(false);
            WrongPopup.Show(false);
        }
    }

    public void Cancel()
    {
        UnlockPopup.Hide(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            UnlockPopup.Show(false);
        if (Input.GetKeyDown(KeyCode.E))
            WrongPopup.Show(false);
    }

}
