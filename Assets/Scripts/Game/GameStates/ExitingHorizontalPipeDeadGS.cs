using UnityEngine;
using System.Collections;
using System;

public class ExitingHorizontalPipeDeadGS : GameState {

    protected override void Enter() {
        OpenCloseCircleStorer.Instance.OpenCloseCircleController.OpenOn(Data.HorizontalPipeEntered);
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return null;
    }

    protected override void Exit() {
    }
}
