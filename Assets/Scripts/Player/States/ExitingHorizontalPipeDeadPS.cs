using UnityEngine;
using System.Collections;
using System;

public class ExitingHorizontalPipeDeadPS : PlayerState {

    private PlayerState _nextState;

    protected override void Enter() {
        _nextState = null;

        Controller.SetExitPosition(GameStorer.Instance.GameData.HorizontalPipeEntered);

        Controller.Add<AngleControlPB>();
        Controller.GravityScale = PlayerSettings.Instance.gravityScale;
        Controller.XVel = GameSettings.Instance.vel;
        Controller.YVel = PlayerSettings.Instance.exitHorizontalPipeYVel;

        Controller.OnDie();

        GameStorer.Instance.GameController.On(GameEvent.BACK_TO_MAIN_MENU, GoNextState);
    }

    private void GoNextState() {
        _nextState = PlayerStatesStorer.Instance.Get<MainMenuPS>();
    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return _nextState;
    }

    protected override void Exit() {
        GameStorer.Instance.GameController.Remove(GameEvent.BACK_TO_MAIN_MENU, GoNextState);
    }
}
