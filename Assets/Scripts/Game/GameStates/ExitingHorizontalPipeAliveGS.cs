using UnityEngine;
using System.Collections;
using System;

public class ExitingHorizontalPipeAliveGS : GameState {

    protected override void Enter() {
        Controller.VelPlayerScenario = Settings.vel;

        OpenCloseCircleStorer.Instance.OpenCloseCircleController.OpenOn(Data.HorizontalPipeEntered);

        Controller.Invoke(GameEvent.EXITING_HORIZONTAL_PIPE_START);
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return null;
    }

    protected override void Exit() {
    }
}
