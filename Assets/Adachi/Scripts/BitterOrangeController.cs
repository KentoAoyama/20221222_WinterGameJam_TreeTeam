using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ãæñ›ÇÃè„Ç…ÇÃÇπÇÈûÚÅiÇæÇ¢ÇæÇ¢Åj
/// </summary>
public class BitterOrangeController : ItemBase
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
        if (collision.gameObject.tag == _playerTag)
        {
            _isMoving = false;
            transform.SetParent(collision.transform);
        }
    }

    async protected override void OnMove()
    {
        while (_isMoving)
        {
            transform.Translate(0f, -_speed, 0f);
            await UniTask.NextFrame();
        }
    }
}
