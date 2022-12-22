using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Cinemachine;
using UniRx;

public class GameManager
{
    private static GameManager _instance = new GameManager();
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError($"Error! Please correct!");
            }
            return _instance;
        }
    }
    private GameManager() { }


    private IntReactiveProperty _score = new ();
    /// <summary>
    /// Ï‚ß‚½–İ‚Ì”
    /// </summary>
    public IntReactiveProperty Score => _score;

    private Stack<GameObject> _mochiStack = new Stack<GameObject>();

    private CinemachineVirtualCamera _cinemachine;
    public CinemachineVirtualCamera Cinemachine { get => _cinemachine; set => _cinemachine = value; }

    public GameObject Player;

    /// <summary>
    /// –İ‚ğStack‚É’Ç‰Á‚·‚éƒƒ\ƒbƒh
    /// </summary>
    public void PushMochi(GameObject mochi)
    {
        _score.Value++;
        _mochiStack.Push(mochi);
        ResetCamera();
    }

    /// <summary>
    /// ”š’e‚ª‚ ‚½‚Á‚½Û‚Ìˆ—
    /// </summary>
    public void BombMochi(int popCount)
    {
        for (int i = 0; i < popCount; i++)
        {
            if (_score.Value <= 0) break;
            _score.Value--;
            var popMochi = _mochiStack.Pop();
            GameObject.Destroy(popMochi);
        }
        ResetCamera();
    }

    private void ResetCamera()
    {
        if (_mochiStack.Count == 0)
        {
            _cinemachine.Follow = Player.transform;
            return;
        }

        _cinemachine.Follow = _mochiStack.First().transform;
    }

    public void Reset()
    {
        _score.Value = 0;
        _cinemachine = default;
    }
}
