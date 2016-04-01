using UnityEngine;
using System.Collections;
using System;

public class JumpStartTutorialPS : PlayerState {

    private bool exit = false;

    protected override void Enter() {
        MainMenuController mainMenuController = UIStorer.Instance.MainMenuController;
        Controller.Add<BeatWingPB>();
        GameStorer.Instance.GameController.On(GameEvent.ON_EXIT_JUMP_START_TUTORIAL, delegate { exit = true; });
    }

    protected override void Exit() {

    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        if(exit)
            return PlayerStatesStorer.Instance.Get<DivertingObstaclesPS>();
        else
            return null;
    }
}
