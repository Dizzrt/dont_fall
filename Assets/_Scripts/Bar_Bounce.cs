using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar_Bounce : MonoBehaviour
{
    Animator ani;
    public float force;

    Coroutine temp;
    private void Awake()
    {
        ani = this.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            ani.Play("Bar_Bounce_ani", 0, 0);
            temp = StartCoroutine(ien(collision));
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            StopCoroutine(temp);
            ani.Play("Bar_Bounce_ani_Back", 0, ani.GetCurrentAnimatorStateInfo(0).normalizedTime);
        }

    }

    IEnumerator ien(Collision2D col)
    {
        yield return new WaitForSeconds(1.5f);
        col.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
    }
}
