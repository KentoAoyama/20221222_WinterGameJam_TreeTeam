using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    [Header("—Ž‰º•¨(–Ý&”š’e)")]
    ItemBase[] _item = new ItemBase[2];

    private void Awake()
    {
        
    }

    async private void Generate()
    {
        await UniTask.Delay(1000);
        while (true)
        {
            //Instantiate(_item);
            await UniTask.Delay(1000);
        }
    }
}
