using UnityEngine;
using System.Collections;
using System;

public class DivertingObstaclesPS : PlayerState {

    private PlayerState _nextState;

    protected override void Enter() {
        _nextState = null;
        Controller.ClearBehaviours();
        Controller.Add<JumpPB>();
        Controller.Add<AirCollisionPB>();
        Controller.Add<FloorCollisionPB>();
        Controller.Add<AngleControlPB>();
        Controller.Add<BeatWingPB>();
        Data.RigidBody.gravityScale = PlayerSettings.Instance.gravityScale;
        Controller.On(PlayerEvent.ON_CHOICE_ANSWER, delegate {
            _nextState = PlayerStatesStorer.Instance.Get<ChoicingAnswerPS>();
        });
        Controller.On(PlayerEvent.ON_ENTER_HORIZONTAL_PIPE_TURORIAL, delegate {
            _nextState = PlayerStatesStorer.Instance.Get<EnterHorizontalPipeTutorialPS>();
        });
    }

    protected override void Exit() {

    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return _nextState;
    }
}
