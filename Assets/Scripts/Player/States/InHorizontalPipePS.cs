using UnityEngine;
using System.Collections;
using System;

public class InHorizontalPipePS : PlayerState {

    private PlayerState _nextState;

    protected override void Enter() {
        _nextState = null;

        Controller.YVel = 0f;
        Controller.XVel = 0f;
        Controller.GravityScale = 0f;

        Controller.On(PlayerEvent.GO_EXITING_ALIVE, GoExitingAlive);
        Controller.On(PlayerEvent.GO_EXITING_DEAD, GoExitingDead);
    }

    private void GoExitingAlive() {
        _nextState = PlayerStatesStorer.Instance.Get<ExitingHorizontalPipeAlivePS>();
    }

    private void GoExitingDead() {
        _nextState = PlayerStatesStorer.Instance.Get<ExitingHorizontalPipeDeadPS>();
    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return _nextState;
    }

    protected override void Exit() {
        Controller.Remove(PlayerEvent.GO_EXITING_ALIVE, GoExitingAlive);
        Controller.Remove(PlayerEvent.GO_EXITING_DEAD, GoExitingDead);
    }
}
