using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginLine : MonoBehaviour
{
    public GameData gd;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bar")
        {
            gd.Data.CurrentSpeed = gd.Data.SpeedLimit.x;
            gd.Data.SpawnTimeDelta = gd.Data.SpawnTimeDeltaLimit.x;
            Destroy(this.gameObject);
        }
    }
}
