using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBorder : MonoBehaviour
{
    public GameData gd;

    public float Direction;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            float temp = 3.5f * Mathf.Abs(collision.transform.GetComponent<Rigidbody2D>().velocity.x);
            collision.transform.GetComponent<PlayerController>().rigi.AddForce((new Vector2(gd.SBD.RightForce * Direction, gd.SBD.UpForce)) * (temp > 1 ? temp : 1));
        }

    }


}
