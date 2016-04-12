using UnityEngine;
using System.Collections;
using System;

public class GameOverGS : GameState {

    private OpenCloseCircleController _openCloseCircleController;
    private GameState _nextState;

    protected override void Enter() {
        _nextState = null;
        _openCloseCircleController = OpenCloseCircleStorer.Instance.OpenCloseCircleController;

        _openCloseCircleController.ClosenOn(Vector3.zero);
        _openCloseCircleController.On(OpenCloseEvent.FINISH_CLOSE, OnFinishClose);
    }

    private void OnFinishClose() {
        _openCloseCircleController.OpenOn(Vector3.zero);
        QuestionBoardStorer.Instance.QuestionBoardController.GoOutNow();
        Controller.Invoke(GameEvent.BACK_TO_MAIN_MENU);
        _nextState = GameStatesStorer.Instance.Get<NoneToMainMenuGS>();
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return _nextState;
    }

    protected override void Exit() {
        _openCloseCircleController.Remove(OpenCloseEvent.FINISH_CLOSE, OnFinishClose);
    }
}
