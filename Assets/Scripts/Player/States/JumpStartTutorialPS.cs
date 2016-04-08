using UnityEngine;
using System.Collections;
using System;

public class JumpStartTutorialPS : PlayerState {

    private bool _exit = false;

    protected override void Enter() {
        Controller.Add<BeatWingPB>();

        GameStorer.Instance.GameController.On(GameEvent.EXIT_JUMP_START_TUTORIAL, OnExitJumpStartTutorial);
    }

    private void OnExitJumpStartTutorial() {
        _exit = true;
    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        if(_exit)
            return PlayerStatesStorer.Instance.Get<DivertingObstaclesPS>();
        else
            return null;
    }

    protected override void Exit() {
        GameStorer.Instance.GameController.Remove(GameEvent.EXIT_JUMP_START_TUTORIAL, OnExitJumpStartTutorial);
    }
}
