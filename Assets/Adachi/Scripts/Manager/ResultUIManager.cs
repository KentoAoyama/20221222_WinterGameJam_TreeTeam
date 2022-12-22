using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUIManager : MonoBehaviour
{
    [SerializeField]
    [Header("キャンバス")]
    Canvas _canvas;

    [SerializeField]
    [Header("スコアのテキスト")]
    Text _scoreText;

    public void ChangeActive()
    {
        _scoreText.text = $"スコア : {GameManager.Instance.Score.Value}";
        _canvas.gameObject.SetActive(true);
    }
}
