using UnityEngine;
using System.Collections;
using System;

public class MainMenuToMatchPS : PlayerState {

    private bool _endMainMenuOutAnim;
    private bool _playerInPos;
    private bool _goToTutorial;
    private bool _goDirectToMatch;

    protected override void Enter() {
        _endMainMenuOutAnim = false;
        _playerInPos = false;
        _goToTutorial = false;
        _goDirectToMatch = false;

        Controller.Add<BeatWingPB>();
        Controller.XVel = -GameSettings.Instance.vel;

        MainMenuController mainMenuController = UIStorer.Instance.MainMenuController;
        mainMenuController.On(MainMenuEvent.OUT_ANIMATION_END, OnMainMenuOutAnimEnd);
        
        GameController gameController = GameStorer.Instance.GameController;
        gameController.On(GameEvent.GO_TO_JUMP_START_TUTORIAL, GoToTutorial);
        gameController.On(GameEvent.GO_DIRECT_TO_MATCH, GoDirectToMatch);
    }

    private void GoToTutorial() {
        _goToTutorial = true;
    }

    private void GoDirectToMatch() {
        _goDirectToMatch = true;
    }

    private void OnMainMenuOutAnimEnd() {
        _endMainMenuOutAnim = true;
    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        if( !_playerInPos ) {
            if(Controller.X < PlayerSettings.Instance.initialX) {
                Controller.XVel = 0f;
                Controller.X = Settings.initialX;
                _playerInPos = true;
            }
        }

        if(_playerInPos && _endMainMenuOutAnim) {
            if( _goToTutorial )
                return PlayerStatesStorer.Instance.Get<JumpStartTutorialPS>();
            else if( _goDirectToMatch)
                return PlayerStatesStorer.Instance.Get<DivertingObstaclesPS>();
        }

        return null;
    }

    protected override void Exit() {
    }
}
