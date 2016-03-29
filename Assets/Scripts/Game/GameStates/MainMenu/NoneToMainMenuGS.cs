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

        ScenariosManager.Instance.Current = ScenarioType.SKY;

        UIFactory.Instance.CreateMainMenu();
        _mainMenuController = UIStorer.Instance.MainMenuController;
        _mainMenuController.On( MainMenuEvent.IN_ANIMATION_END, delegate { _nextState = GameStatesStorer.Instance.Get<MainMenuGS>(); } );
        _mainMenuController.gameObject.SetActive(false);

        PlayerFactory.Instance.CreatePlayer();
        _playerController = PlayerStorer.Instance.PlayerController;
        _playerController.OnAfterStart(delegate { _playerController.NormalizedVel = 0.0f; });

        _delta = 0.0f;
        _inAnimationInitialized = false;
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        _delta += Time.deltaTime;
        if(!_inAnimationInitialized && _delta >= GameSettings.Instance.initMainMenuDelay) {
            _mainMenuController.gameObject.SetActive(true);
            _mainMenuController.InitInAnimation();
            _inAnimationInitialized = true;
        }

        return _nextState;
    }

    protected override void Exit() {
    }
}
