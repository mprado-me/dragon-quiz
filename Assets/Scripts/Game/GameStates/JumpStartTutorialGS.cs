using UnityEngine;
using System.Collections;

public class JumpStartTutorialGS : GameState {

    protected override void Enter() {
        ScenariosManager.Instance.vel = 0.0f;
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            return GameStatesStorer.Instance.Get<DivertingObstaclesGS>();
        else
            return null;
    }

    protected override void Exit() {
    }
}
