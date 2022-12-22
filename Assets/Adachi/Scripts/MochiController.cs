using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochiController : ItemBase
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
        if(collision.gameObject.tag == _playerTag)
        {
            _isMoving = false;
            gameObject.tag = _playerTag;
        }
    }

    async protected override void OnMove()
    {
        while(_isMoving)
        {
            transform.Translate(0f, -_speed, 0f);
            await UniTask.NextFrame();
        }
    }
}
