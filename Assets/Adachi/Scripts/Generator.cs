using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

public class Generator : MonoBehaviour
{
    [SerializeField]
    [Header("生成された餅&爆弾のY軸")]
    float _posY;

    [SerializeField]
    [Header("クールタイム")]
    Value<int> _coolTime;

    [SerializeField]
    [Header("x軸の範囲")]
    Value<float> _posXRange;

    [SerializeField]
    [Header("カメラ")]
    Camera _camera;

    [SerializeField]
    [Header("最後にのせる橙")]
    BitterOrangeController _bitterOrange;

    [SerializeField]
    [Header("落下物(餅&爆弾)")]
    ItemData[] _item = new ItemData[2];

    private bool _isGenerating = true;

    const float MAX_VALUE_F = 100f;

    private void Awake()
    {
        float _firstPosY = _posY;
        _camera
            .ObserveEveryValueChanged(camera => camera.transform.position.y)
            .Subscribe(y => _posY = _firstPosY + y);
        Generate();
    }

    /// <summary>
    /// 最後に橙を生成する
    /// 残り時間が最後の方になったら呼び出してください
    /// </summary>
    public void ChangeIsGenerating()
    {
        _isGenerating = false;
    }

    async private void Generate()
    {
        var randomTime = Random.Range(_coolTime.MinValue, _coolTime.MaxValue);
        await UniTask.Delay(randomTime);

        float randomPosX = 0f;

        while (_isGenerating)
        {
            var item = Instantiate(_item[RandomIndex(_item)].Item);
            item.transform.SetParent(transform);

            randomPosX = Random.Range(_posXRange.MinValue, _posXRange.MaxValue);
            item.transform.ChangePosX(randomPosX);
            item.transform.ChangePosY(_posY);

            randomTime = Random.Range(_coolTime.MinValue, _coolTime.MaxValue);
            await UniTask.Delay(randomTime);
        }

        var bitterOrange = Instantiate(_bitterOrange);
        bitterOrange.transform.SetParent(transform);

        randomPosX = Random.Range(_posXRange.MinValue, _posXRange.MaxValue);
        bitterOrange.transform.ChangePosX(randomPosX);
        bitterOrange.transform.ChangePosY(_posY);
    }

    /// <summary>
    /// ガチャのような関数
    /// </summary>
    /// <param name="num">確率</param>
    /// <returns>Index</returns>
    private int RandomIndex(ItemData[] num)
    {
        float[] probability = null;
        var sum = num.Select(x => x.Probability).Sum();
        var limitCount = 1;
        System.Array.Resize(ref probability, num.Length);
        for (int index = 0; index < num.Length; index++)
        {
            for (int count = 0; count < limitCount; count++)
            {
                probability[index] += num[count].Probability * MAX_VALUE_F / sum;
            }
            //Debug.Log(index + "番目 " + probability[index]);
            limitCount++;
        }
        var randomValue = Random.Range(0f, MAX_VALUE_F);
        //Debug.Log("乱数 " + randomValue);
        for (int i = 0; i < probability.Length; i++)
        {
            if (probability[i] > randomValue)
            {
                //Debug.Log("結果は" + i);
                return i;
            }
        }
        return 0;
    }
}
