using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : ItemBase
{
    private void Awake()
    {
        OnMove();
    }

    protected override void OnBecameInvisible()
    {
        _isMoving = false;
        Destroy(gameObject);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        _isMoving = false;
        //GameManager‚ª‚Á‚Ä‚¢‚éŠÖ”‚ğŒÄ‚Ño‚·
    }

    async protected override void OnMove()
    {
        while(_isMoving)
        {
            transform.Translate(0f,-_speed,0f);
            await UniTask.NextFrame();
        }
    }
}
