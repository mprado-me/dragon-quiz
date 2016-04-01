using UnityEngine;
using System.Collections;
using System;

public class MainMenuToMatchGS : GameState {

    private GameState _newState;
    private bool tutorialShowed;

    public MainMenuToMatchGS() {
    }

    protected override void Enter() {
        _newState = null;
        MainMenuController mainMenuController = UIStorer.Instance.MainMenuController;
        mainMenuController.On(MainMenuEvent.OUT_ANIMATION_END, delegate {
            if(!tutorialShowed) {
                tutorialShowed = true;
                _newState = GameStatesStorer.Instance.Get<JumpStartTutorialGS>();
            } else {
                _newState = GameStatesStorer.Instance.Get<DivertingObstaclesGS>();
            }
        });
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return _newState;
    }

    protected override void Exit() {
    }
}