using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Value<T>
{
    #region Public Properties

    public T MinValue => _minValue;
    public T MaxValue => _maxValue;

    #endregion

    #region Inspector Member

    [SerializeField]
    [Header("è¨Ç≥Ç¢íl")]
    private T _minValue;

    [SerializeField]
    [Header("ëÂÇ´Ç¢íl")]
    private T _maxValue;

    #endregion

    #region Public Method

    public void ChangeValue(T minValue, T maxValue)
    {
        _minValue = minValue;
        _maxValue = maxValue;
    }

    #endregion
}
