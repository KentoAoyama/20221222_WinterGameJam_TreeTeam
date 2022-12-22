using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BombDestrtoy
{
    public class BombChange : ItemBase
    {
        [SerializeField]
        [Header("Á‚·–İ‚Ì”")]
        private int _popCount = 4;

        [SerializeField]
        private float _destroyIntervel = 3f;

        private float _timer;

        private void Awake()
        {
            OnMove();
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer > _destroyIntervel)
            {
                Destroy(gameObject);
            }
        }

        protected override void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == _playerTag)
            {
                _isMoving = false;
                Destroy(gameObject);
                //GameManager‚ª‚Á‚Ä‚¢‚éŠÖ”‚ğŒÄ‚Ño‚·
                GameManager.Instance.BombMochi(_popCount);
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

        protected override void OnBecameInvisible()
        {
            throw new System.NotImplementedException();
        }
    }
}
