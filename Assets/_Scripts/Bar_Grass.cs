using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar_Grass : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
            collision.transform.GetComponent<Rigidbody2D>().velocity
                = new Vector2(0, collision.transform.GetComponent<Rigidbody2D>().velocity.y);
    }
}
