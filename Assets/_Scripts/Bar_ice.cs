using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar_ice : MonoBehaviour
{
    public float iceSpeed = 200;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
            collision.transform.GetComponent<PlayerController>().Moce_Speed = iceSpeed;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
            collision.transform.GetComponent<PlayerController>().Moce_Speed
                = collision.transform.GetComponent<PlayerController>().Default_Speed;
    }
}
