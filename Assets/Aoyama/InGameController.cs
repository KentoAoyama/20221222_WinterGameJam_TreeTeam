using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class InGameController : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private Text _timeText;

    [SerializeField]
    private CinemachineVirtualCamera _cinemachine;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Cinemachine = _cinemachine;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetText()
    {
        //_scoreText.text = _score.ToString();
        //_timeText.text = _time.ToString();
    }
}
