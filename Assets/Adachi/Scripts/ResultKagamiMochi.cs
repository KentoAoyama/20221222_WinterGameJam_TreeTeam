using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// リザルト用の鏡餅
/// </summary>
public class ResultKagamiMochi : MonoBehaviour
{
    [SerializeField]
    [Header("リザルト用UIマネージャー")]
    ResultUIManager _resultUIManager;

    [SerializeField]
    [Header("餅")]
    MochiController _mochi;

    [SerializeField]
    [Header("橙")]
    BitterOrangeController _bitterOrange;

    [SerializeField]
    [Header("鏡餅を生成するクールタイム(ミリ秒)")]
    int _coolTime = 500;

    [SerializeField]
    [Header("生成位置(Y)")]
    float _posY = 7f;

    async private void Awake()
    {
        await InstantiateMochi();
        _resultUIManager.ChangeActive();
    }

    async private UniTask InstantiateMochi()
    {
        for (int i = 0; i < GameManager.Instance.Score.Value; i++)
        {
            var mochi = Instantiate(_mochi);
            mochi.transform.SetParent(transform);
            mochi.transform.ChangePosX(-0.73f);
            mochi.transform.ChangePosY(_posY);
            await UniTask.Delay(_coolTime);
        }

        var bitterOrange = Instantiate(_bitterOrange);
        bitterOrange.transform.SetParent(transform);
        bitterOrange.transform.ChangePosX(0f);
        bitterOrange.transform.ChangePosY(_posY);
    }
}
