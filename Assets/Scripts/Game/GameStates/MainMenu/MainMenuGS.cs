using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MainMenuGS : GameState {

    private GameState _nextState;
    MainMenuController _mainMenuController;

    public MainMenuGS() {
    }

    protected override void Enter() {
        _nextState = null;

        _mainMenuController = UIStorer.Instance.MainMenuController;
        _mainMenuController.On(MainMenuEvent.PLAY_BUTTON_CLICK, GoNextState);
    }

    private void GoNextState() {
        _nextState = GameStatesStorer.Instance.Get<MainMenuToMatchGS>();
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return _nextState;
    }

    protected override void Exit() {
        _mainMenuController.Remove(MainMenuEvent.PLAY_BUTTON_CLICK, GoNextState);
    }
}