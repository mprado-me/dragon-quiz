using UnityEngine;
using System.Collections;
using System;

public class NoneToMainMenuGS : GameState {

    private GameState _nextState;
    private PlayerController _playerController;
    private MainMenuController _mainMenuController;
    private bool _inAnimationInitialized;
    private float _delta;

    public NoneToMainMenuGS() {
    }

    protected override void Enter() {
        _nextState = null;
        _delta = 0f;
        _inAnimationInitialized = false;

        PlayerFactory.Instance.CreatePlayer();
        UIFactory.Instance.CreateMainMenu();

        Controller.VelPlayerScenario = Settings.vel;

        _playerController = PlayerStorer.Instance.PlayerController;
        _playerController.XVel = 0f;

        ScenariosManager.Instance.Current = ScenarioType.SKY;

        _mainMenuController = UIStorer.Instance.MainMenuController;
        _mainMenuController.On(MainMenuEvent.IN_ANIMATION_END, GoNextState);
        _mainMenuController.gameObject.SetActive(false);
    }

    private void GoNextState() {
        _nextState = GameStatesStorer.Instance.Get<MainMenuGS>();
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        _delta += Time.deltaTime;
        if(!_inAnimationInitialized && _delta >= Settings.initMainMenuDelay) {
            _mainMenuController.gameObject.SetActive(true);
            _mainMenuController.InitInAnimation();
            _inAnimationInitialized = true;
        }

        return _nextState;
    }

    protected override void Exit() {
        _mainMenuController.Remove(MainMenuEvent.IN_ANIMATION_END, GoNextState);
    }
}