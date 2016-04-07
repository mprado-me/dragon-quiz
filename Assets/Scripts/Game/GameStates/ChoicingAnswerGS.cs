using UnityEngine;
using System.Collections;
using System;

public class ChoicingAnswerGS : GameState {

    protected override void Enter() {
        Controller.ClearBehaviours();
        ScenariosManager.Instance.vel = 0.0f;
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return null;
    }

    protected override void Exit() {
    }
}
