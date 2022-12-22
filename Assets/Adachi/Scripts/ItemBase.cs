using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField]
    [Header("落下スピード")]
    [Range(0f,1f)]
    protected float _speed = 0.05f;

    protected bool _isMoving = true;

    protected abstract void OnCollisionEnter(Collision collision);

    protected abstract void OnBecameInvisible();

    protected abstract void OnMove();
}
