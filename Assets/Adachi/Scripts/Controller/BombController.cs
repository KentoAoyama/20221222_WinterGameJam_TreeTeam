using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : ItemBase
{
    [SerializeField]
    [Header("Á‚·–İ‚Ì”")]
    private int _popCount = 4;

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

            SoundManager.Instance.PlaySFX(SFXNames.EXPLOSION);

            //GameManager‚ª‚Á‚Ä‚¢‚éŠÖ”‚ğŒÄ‚Ño‚·
            GameManager.Instance.BombMochi(_popCount);

            Destroy(gameObject);
        }
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
