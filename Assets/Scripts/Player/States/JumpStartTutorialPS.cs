using UnityEngine;
using System.Collections;
using System;

public class JumpStartTutorialPS : PlayerState {


    protected override void Enter() {
        MainMenuController mainMenuController = UIStorer.Instance.MainMenuController;
        Controller.Add<BeatWingPB>();
    }

    protected override void Exit() {

    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return PlayerStatesStorer.Instance.Get<DivertingVerticalPipesPS>();
    }
}
