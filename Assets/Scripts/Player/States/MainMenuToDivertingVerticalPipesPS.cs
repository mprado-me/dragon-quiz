using UnityEngine;
using System.Collections;
using System;

public class MainMenuToDivertingVerticalPipesPS : PlayerState {
    PlayerState _nextPlayerState;

    protected override void Enter() {
        _nextPlayerState = null;
        MainMenuController mainMenuController = UIStorer.Instance.MainMenuController;
        mainMenuController.On(MainMenuEvent.OUT_ANIMATION_END, delegate { _nextPlayerState = PlayerStatesStorer.Instance.Get<DivertingVerticalPipesPS>(); });
    }

    protected override void Exit() {

    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return _nextPlayerState;
    }
}
