using DG.Tweening.Plugins;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameData gd;
    public TextMeshProUGUI title;

    public Animator ani;
    public Rigidbody2D rigi;

    private float _InputX;
    public float Moce_Speed = 100;
    public float Default_Speed = 100;

    [Header("On Ground Check")]
    public bool OnGround;
    public float CheckDistance;
    public LayerMask CheckLayer;

    private void Update()
    {
        //mobile input
        //_InputX = Input.acceleration.x;
        //rigi.AddForce(Vector2.right * _InputX * Time.deltaTime * Moce_Speed);

        //pc input
        rigi.AddForce(Vector2.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * Moce_Speed);

        OnGround = Physics2D.OverlapCircle(transform.position, CheckDistance, CheckLayer);

        if (Input.GetMouseButton(0) && OnGround && gd.JumpForce < gd.Data.MaxJumpForce)
            gd.JumpForce += gd.Data.JumpForceRate * Time.deltaTime;
        if (Input.GetMouseButtonUp(0) && OnGround)
        {
            rigi.AddForce(Vector2.up * gd.JumpForce);
            gd.JumpForce = 0;
        }
    }

    public void AddScore()
    {
        gd.Score++;
        title.text = "得分:" + gd.Score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Bot" && gd.Score > 0)
        {
            string temp = "History_";

            if (gd.GameMode == 0)
                temp += "normal_";
            else temp += "muti_";

            if (gd.degree == 0)
                temp += "eazy";
            else temp += "hard";

            PlayerPrefs.SetInt("Score", gd.Score);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + PlayerPrefs.GetInt("Score"));

            if (gd.Score > PlayerPrefs.GetInt(temp, 0))
            {
                PlayerPrefs.SetInt(temp, gd.Score);
                PlayerPrefs.SetInt("NewRecord", 1);
            }
            SceneManager.LoadScene(1);
        }
    }

    //Debug Check Distance
    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, CheckDistance);
    //}
}
