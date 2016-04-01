using UnityEngine;
using System.Collections;
using System;

public class DivertingObstaclesGS : GameState {

    private float delta;

    public DivertingObstaclesGS() {
    }

    protected override void Enter() {
        delta = 0.0f;
        ScenariosManager.Instance.vel = ScenarioSettings.Instance.vel;
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