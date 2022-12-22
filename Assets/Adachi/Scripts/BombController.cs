using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : ItemBase
{

    protected override void OnBecameInvisible()
    {
        Destroy(this);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        //GameManagerが持っている関数を呼び出す
    }
}
