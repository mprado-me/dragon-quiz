using UnityEngine;
using System.Collections;
using System;

public class MainMenuPS : PlayerState {
    PlayerState _nextPlayerState;

    protected override void Enter() {
        _nextPlayerState = null;
        MainMenuController mainMenuController = UIStorer.Instance.MainMenuController;
        mainMenuController.On(MainMenuEvent.PLAY_BUTTON_CLICK, delegate { _nextPlayerState = PlayerStatesStorer.Instance.Get<MainMenuToDivertingVerticalPipesPS>(); });
    }

    protected override void Exit() {

    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return _nextPlayerState;
    }
}
