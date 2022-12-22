using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Cinemachine;

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

    private int _score = 0;

    private float _time = 0f;

    private Stack<GameObject> _mochiStack = new Stack<GameObject>();

    public CinemachineVirtualCamera Cinemachine;

    public void PushMochi(GameObject mochi)
    {
        _mochiStack.Push(mochi);
        ResetCamera();
    }

    public void BombMochi(int popCount)
    {
        for (int i = 0; i < popCount; i++)
        {
            _mochiStack.Pop();
        }
        ResetCamera();
    }

    private void ResetCamera()
    {
        Cinemachine.Follow = _mochiStack.Last().transform;
    }

    public void Reset()
    {

    }
}
