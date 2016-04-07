using UnityEngine;
using System.Collections;
using System;

public class EnterHorizontalPipeTutorialGS : GameState {

    protected override void Enter() {
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return GameStatesStorer.Instance.Get<ChoicingAnswerGS>();
    }

    protected override void Exit() {
    }
}
