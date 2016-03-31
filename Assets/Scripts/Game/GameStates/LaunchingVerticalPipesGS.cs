using UnityEngine;
using System.Collections;
using System;

public class LaunchingVerticalPipesGS : GameState {

    private float delta;

    public LaunchingVerticalPipesGS() {
    }

    protected override void Enter() {
        delta = 0.0f;
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        delta += Time.deltaTime;
        if( delta >= GameSettings.Instance.launchFixedVerticalPipePeriod) {
            delta = 0.0f;
            PipesFactory.Instance.CreateFixesVerticalPipe();
        }
        return null;
    }

    protected override void Exit() {

    }
}