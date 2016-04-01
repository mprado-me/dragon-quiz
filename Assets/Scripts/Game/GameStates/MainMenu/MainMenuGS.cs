using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MainMenuGS : GameState {

    private GameState _nextState;

    public MainMenuGS() {
    }

    protected override void Enter() {
        _nextState = null;
        MainMenuController mainMenuController = UIStorer.Instance.MainMenuController;
        mainMenuController.On(MainMenuEvent.PLAY_BUTTON_CLICK, delegate { _nextState = GameStatesStorer.Instance.Get<MainMenuToMatchGS>(); });
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return _nextState;
    }

    protected override void Exit() {

    }
}