using UnityEngine;
using System.Collections;
using System;

public class EnterHorizontalPipeTutorialPS : PlayerState {

    protected override void Enter() {
    }

    protected override void Exit() {
    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return PlayerStatesStorer.Instance.Get<ChoicingAnswerPS>();
    }
}
