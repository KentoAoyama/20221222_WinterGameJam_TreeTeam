using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 鏡餅の下の部分、リザルト用
/// </summary>
public class Sanpo : MonoBehaviour
{
    [SerializeField]
    [Header("餅のタグ")]
    private string _mochiTag = "Mochi";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == _mochiTag)
        {
            collision.transform.SetParent(transform);
        }
    }
}
