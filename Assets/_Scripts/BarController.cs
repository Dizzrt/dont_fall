using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    public bool touched = false;

    private GameData gd;
    private void Awake()
    {
        gd = GameObject.Find("GameMananger").GetComponent<GameData>();
    }
    private void Update()
    {
        transform.Translate(-Vector3.up * gd.Data.CurrentSpeed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "DestoryLine")
            Destroy(this.gameObject);

        if (collision.transform.tag == "Player" && !touched)
        {
            collision.transform.GetComponent<PlayerController>().AddScore();
            touched = !touched;
        }
    }
}
