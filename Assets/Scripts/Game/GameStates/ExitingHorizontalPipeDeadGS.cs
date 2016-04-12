using UnityEngine;
using System.Collections;
using System;

public class ExitingHorizontalPipeDeadGS : GameState {

    private GameState _nextState;

    protected override void Enter() {
        _nextState = null;

        Controller.VelPlayerScenario = Settings.vel;

        OpenCloseCircleStorer.Instance.OpenCloseCircleController.OpenOn(Data.HorizontalPipeEntered);

        Controller.Invoke(GameEvent.EXITING_HORIZONTAL_PIPE_START);
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return _nextState;
    }

    protected override void Exit() {
    }
}
