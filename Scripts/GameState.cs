using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum State { Play, Pause }

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }

    public State CurrentState { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeState(State _newState)
    {
        CurrentState = _newState;
    }
    public bool IsPlay()
    {
        return CurrentState == State.Play;
    }
    public bool IsPause()
    {
        return CurrentState != State.Pause;
    }
}
