using UnityEngine;
using System.Collections;
using System;

public class MainMenuToMatchGS : GameState {

    private GameState _nextState;
    MainMenuController _mainMenuController;

    public MainMenuToMatchGS() {
    }

    protected override void Enter() {
        _nextState = null;

        _mainMenuController = UIStorer.Instance.MainMenuController;
        _mainMenuController.On(MainMenuEvent.OUT_ANIMATION_END, GoNextState);
    }

    private void GoNextState() {
        if(!Data.TutorialAlreadyShowed) {
            Data.TutorialAlreadyShowed = true;
            Controller.Invoke(GameEvent.GO_TO_JUMP_START_TUTORIAL);
            _nextState = GameStatesStorer.Instance.Get<JumpStartTutorialGS>();
        }
        else {
            Controller.Invoke(GameEvent.GO_DIRECT_TO_MATCH);
            _nextState = GameStatesStorer.Instance.Get<DivertingObstaclesGS>();
        }
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return _nextState;
    }

    protected override void Exit() {
        _mainMenuController.Remove(MainMenuEvent.OUT_ANIMATION_END, GoNextState);
    }
}