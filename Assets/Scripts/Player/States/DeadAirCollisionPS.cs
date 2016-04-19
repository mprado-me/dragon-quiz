using UnityEngine;
using System.Collections;
using System;

public class DeadAirCollisionPS : PlayerState {

    private float _delta;
    private PlayerState _nextState;
    private GameController _gameController;

    protected override void Enter() {
        _delta = 0f;
        _nextState = null;

        Controller.Add<AngleControlPB>();
        Controller.Add<FloorCollisionPB>();
        Controller.XVel = 0f;
        Controller.YVel = 0f;

        _gameController = GameStorer.Instance.GameController;
        _gameController.VelPlayerScenario = 0f;

        Controller.OnDie();

        _gameController.On(GameEvent.BACK_TO_MAIN_MENU, GoMainMenuPS);
        _gameController.On(GameEvent.GO_TO_JUMP_START_TUTORIAL, GoJumpStartTutorialPS);
    }

    private void GoJumpStartTutorialPS() {
        _nextState = PlayerStatesStorer.Instance.Get<JumpStartTutorialPS>();
    }

    private void GoMainMenuPS() {
        _nextState = PlayerStatesStorer.Instance.Get<MainMenuPS>();
    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        _delta += Time.deltaTime;
        if( _delta > GameSettings.Instance.timeToGoGameOverState) {
            GameStorer.Instance.GameController.Invoke(GameEvent.GO_GAME_OVER);
        }
        return _nextState;
    }

    protected override void Exit() {
        _gameController.Remove(GameEvent.BACK_TO_MAIN_MENU, GoMainMenuPS);
        _gameController.Remove(GameEvent.GO_TO_JUMP_START_TUTORIAL, GoJumpStartTutorialPS);
    }
}
