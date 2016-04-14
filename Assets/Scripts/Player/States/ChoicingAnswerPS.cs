using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

public class ChoicingAnswerPS : PlayerState {

    private PlayerState _nextState;

    protected override void Enter() {
        _nextState = null;

        JumpPB jumpPB = Controller.Add<JumpPB>();
        if( Data.LastStateType == typeof(EnterHorizontalPipeTutorialPS) )
            jumpPB.missFirstJumpCommand();
        Controller.Add<AirCollisionPB>();
        Controller.Add<FloorCollisionPB>();
        Controller.Add<AngleControlPB>();
        Controller.Add<BeatWingPB>();
        Controller.GravityScale = Settings.gravityScale;
        Controller.XVel = GameSettings.Instance.vel;

        GameStorer.Instance.GameController.On(GameEvent.PLAYER_IN_HORIZONTAL_PIPE, GoNextState);
    }

    private void GoNextState() {
        _nextState = PlayerStatesStorer.Instance.Get<InHorizontalPipePS>();
    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return _nextState;
    }

    protected override void Exit() {
    }
}
