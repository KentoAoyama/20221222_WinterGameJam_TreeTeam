using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 餅や爆弾の基底クラス
/// </summary>
public abstract class ItemBase : MonoBehaviour
{
    [SerializeField]
    [Header("落下スピード")]
    [Range(0f,0.1f)]
    protected float _speed = 0.05f;

    [SerializeField]
    [Header("プレイヤ-のタグ")]
    protected string _playerTag = "Player";

    protected bool _isMoving = true;

    protected abstract void OnCollisionEnter(Collision collision);

    protected abstract void OnBecameInvisible();

    protected abstract void OnMove();
}
