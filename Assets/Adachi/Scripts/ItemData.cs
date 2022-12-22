using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemData
{
    public ItemBase Item => _item;
    public float Probability => _probability;

    [SerializeField]
    [Header("アイテム")]
    ItemBase _item;

    [SerializeField]
    [Header("確率")]
    float _probability;
}
