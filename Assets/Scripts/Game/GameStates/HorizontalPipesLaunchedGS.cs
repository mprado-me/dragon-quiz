using UnityEngine;
using System.Collections;
using System;

public class HorizontalPipesLaunchedGS : GameState {

    protected override void Enter() {
        PipesFactory.Instance.CreateUpHorizontalPipe();
        PipesFactory.Instance.CreateDownHorizontalPipe();
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return null;
    }

    protected override void Exit() {
    }
}
