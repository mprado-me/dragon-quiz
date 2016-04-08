using UnityEngine;
using System.Collections;
using System;

public class NoneToMainMenuPS : PlayerState {
    PlayerState _nextState;
    MainMenuController _mainMenuController;

    protected override void Enter() {
        _nextState = null;

        Controller.Add<BeatWingPB>();

        _mainMenuController = UIStorer.Instance.MainMenuController;
        _mainMenuController.On(MainMenuEvent.IN_ANIMATION_END, GoNextState);
    }

    private void GoNextState() {
        _nextState = PlayerStatesStorer.Instance.Get<MainMenuPS>();
    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return _nextState;
    }

    protected override void Exit() {
        _mainMenuController.Remove(MainMenuEvent.IN_ANIMATION_END, GoNextState);
    }
}
