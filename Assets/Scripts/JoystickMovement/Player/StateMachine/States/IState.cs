using UnityEngine;

public interface IState
{
    void Enter();
    void Exit();
    void Update();
}