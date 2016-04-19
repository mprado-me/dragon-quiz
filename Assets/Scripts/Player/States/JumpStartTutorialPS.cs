using UnityEngine;
using System.Collections;
using System;

public class JumpStartTutorialPS : PlayerState {

    private bool _exit;

    protected override void Enter() {
        _exit = false;

        Controller.Add<BeatWingPB>();

        Controller.X = PlayerSettings.Instance.initialX;
        Controller.Y = PlayerSettings.Instance.PlayerInitialPos.y;
        Controller.YVel = 0f;
        Controller.XVel = 0f;
        Controller.GravityScale = 0f;
        Controller.Ang = 0f;
        Controller.AngVel = 0f;

        Controller.OnLive();

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
