using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MochiController : ItemBase
{
    private void Awake()
    {
        
    }

    protected override void OnBecameInvisible()
    {
        Destroy(this);
    }

    protected override void OnCollisionEnter(Collision collision)
    {

    }
}
