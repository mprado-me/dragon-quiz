using UnityEngine;
using System.Collections;
using System;

public class NoneToMainMenuGS : GameState {

    private GameState _nextState;
    private PlayerController _playerController;

    public NoneToMainMenuGS() {
    }

    protected override void Enter() {
        _nextState = null;

        ScenariosManager.Instance.Current = ScenarioType.SKY;

        UIFactory.Instance.CreateMainMenu();
        MainMenuController mainMenuController = UIStorer.Instance.MainMenuController;
        mainMenuController.InitInAnimation();
        mainMenuController.On( MainMenuEvent.IN_ANIMATION_END, delegate { _nextState = GameStatesStorer.Instance.Get<MainMenuGS>(); } );

        PlayerFactory.Instance.CreatePlayer();
        _playerController = PlayerStorer.Instance.PlayerController;
        _playerController.OnAfterStart(delegate { _playerController.NormalizedVel = 0.0f; });
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return _nextState;
    }

    protected override void Exit() {
    }
}
