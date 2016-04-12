using UnityEngine;
using System.Collections;
using System;

public class MainMenuPS : PlayerState {
    PlayerState _nextPlayerState;
    MainMenuController _mainMenuController;

    protected override void Enter() {
        _nextPlayerState = null;

        Controller.Add<BeatWingPB>();

        Controller.Position = PlayerSettings.Instance.PlayerInitialPos;
        Controller.XVel = 0f;
        Controller.YVel = 0f;
        Controller.GravityScale = 0f;
        Controller.OnLive();
        Controller.Ang = 0f;
        Controller.AngularVel = 0f;

        _mainMenuController = UIStorer.Instance.MainMenuController;
        _mainMenuController.On(MainMenuEvent.PLAY_BUTTON_CLICK, GoNextState);
    }

    private void GoNextState() {
        _nextPlayerState = PlayerStatesStorer.Instance.Get<MainMenuToMatchPS>();
    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return _nextPlayerState;
    }

    protected override void Exit() {
        _mainMenuController.Remove(MainMenuEvent.PLAY_BUTTON_CLICK, GoNextState);
    }
}
