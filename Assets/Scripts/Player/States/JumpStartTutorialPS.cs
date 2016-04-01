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
        if(Input.GetKeyDown(KeyCode.Mouse0))
            return PlayerStatesStorer.Instance.Get<DivertingObstaclesPS>();
        else
            return null;
    }
}
