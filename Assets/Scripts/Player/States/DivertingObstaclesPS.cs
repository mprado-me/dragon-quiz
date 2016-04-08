using UnityEngine;
using System.Collections;
using System;

public class DivertingObstaclesPS : PlayerState {

    private PlayerState _nextState;

    protected override void Enter() {
        _nextState = null;

        Controller.Add<JumpPB>();
        Controller.Add<AirCollisionPB>();
        Controller.Add<FloorCollisionPB>();
        Controller.Add<AngleControlPB>();
        Controller.Add<BeatWingPB>();
        Controller.GravityScale = PlayerSettings.Instance.gravityScale;

        Controller.On(PlayerEvent.GO_CHOICE_ANSWER, GoToChoiceAnswer);
        Controller.On(PlayerEvent.GO_ENTER_HORIZONTAL_PIPE_TURORIAL, GoToEnterHorizontalPipe);
    }

    private void GoToChoiceAnswer() {
        _nextState = PlayerStatesStorer.Instance.Get<ChoicingAnswerPS>();
    }

    private void GoToEnterHorizontalPipe() {
        _nextState = PlayerStatesStorer.Instance.Get<EnterHorizontalPipeTutorialPS>();
    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return _nextState;
    }

    protected override void Exit() {
        Controller.Remove(PlayerEvent.GO_CHOICE_ANSWER, GoToChoiceAnswer);
        Controller.Remove(PlayerEvent.GO_ENTER_HORIZONTAL_PIPE_TURORIAL, GoToEnterHorizontalPipe);
    }
}
