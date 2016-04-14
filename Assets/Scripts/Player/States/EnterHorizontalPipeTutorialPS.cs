using UnityEngine;
using System.Collections;
using System;

public class EnterHorizontalPipeTutorialPS : PlayerState {

    private float _yVel;
    private float _xVel;
    private float _angVel;
    private PlayerState _nextState;
    private GameController _gameController;

    protected override void Enter() {
        _xVel = Controller.XVel;
        _yVel = Controller.YVel;
        _angVel = Controller.AngVel;
        _nextState = null;

        Controller.XVel = 0f;
        Controller.YVel = 0f;
        Controller.GravityScale = 0f;
        Controller.AngVel = 0f;

        _gameController = GameStorer.Instance.GameController;
        _gameController.On(GameEvent.GO_OUT_ENTER_PIPE_TUTORIAL, GoNextState);
    }

    private void GoNextState() {
        _nextState = PlayerStatesStorer.Instance.Get<ChoicingAnswerPS>();
    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return _nextState;
    }

    protected override void Exit() {
        Controller.AngVel = _angVel;
        Controller.XVel = _xVel;
        Controller.YVel = _yVel;
        Controller.GravityScale = PlayerSettings.Instance.gravityScale;

        _gameController.Remove(GameEvent.GO_OUT_ENTER_PIPE_TUTORIAL, GoNextState);
    }
}
