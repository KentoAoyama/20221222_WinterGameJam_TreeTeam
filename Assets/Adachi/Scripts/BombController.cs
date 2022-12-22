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
        //GameManager‚ª‚Á‚Ä‚¢‚éŠÖ”‚ğŒÄ‚Ño‚·
    }
}
