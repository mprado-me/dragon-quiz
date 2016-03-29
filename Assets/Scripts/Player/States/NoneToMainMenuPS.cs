using UnityEngine;
using System.Collections;
using System;

public class NoneToMainMenuPS : PlayerState {

    PlayerState _nextPlayerState;

    protected override void Enter() {
        _nextPlayerState = null;
        MainMenuController mainMenuController = UIStorer.Instance.MainMenuController;
        Controller.Add<BeatWingPB>();
        mainMenuController.On(MainMenuEvent.IN_ANIMATION_END, delegate { _nextPlayerState = PlayerStatesStorer.Instance.Get<MainMenuPS>(); });
    }

    protected override void Exit() {

    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return _nextPlayerState;
    }
}
