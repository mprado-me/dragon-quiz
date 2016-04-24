using UnityEngine;
using System.Collections;
using System;

public class GameOverGS : GameState {

    private OpenCloseCircleController _openCloseCircleController;
    private GameState _nextState;
    private GameOverMenuController _gameOverMenuController;

    protected override void Enter() {
        _nextState = null;
        _openCloseCircleController = OpenCloseCircleStorer.Instance.OpenCloseCircleController;

        DistanceMarkerController distanceMarkerController = MarkersStorer.Instance.DistanceMarkerController;
        CorrectAnswersMarkerController correctAnswersMarkerController = MarkersStorer.Instance.CorrectAnswersMarkerController;

        bool distanceRecord = distanceMarkerController.GetDistance() > Data.DistanceRecord;
        if(distanceRecord)
            Data.DistanceRecord = distanceMarkerController.GetDistance();

        bool correctAnswersRecord = correctAnswersMarkerController.GetNCorrectAnswers() > Data.NCorrectAnswersRecord;
        if(correctAnswersRecord)
            Data.NCorrectAnswersRecord = correctAnswersMarkerController.GetNCorrectAnswers();

        _gameOverMenuController = UIFactory.Instance.CreateGameOverMenu(
            correctAnswersMarkerController.GetNCorrectAnswers(),
            correctAnswersRecord,
            Data.NCorrectAnswersRecord,
            distanceMarkerController.GetDistance(),
            distanceRecord,
            Data.DistanceRecord
            );

        distanceMarkerController.SetInactive();

        correctAnswersMarkerController.SetInactive();

        _gameOverMenuController.On(GameOverMenuEvent.TRY_AGAIN_BUTTON_CLICK, OnTryAgainButtonClick);
        _gameOverMenuController.On(GameOverMenuEvent.MAIN_MENU_BUTTON_CLICK, OnMainMenuButtonClick);
    }

    private void OnTryAgainButtonClick() {
        GameEffectSoundManager.Instance.PlayButtonClick();
        _openCloseCircleController.ClosenOn(Vector3.zero);
        _openCloseCircleController.On(OpenCloseEvent.FINISH_CLOSE, OnFinishCloseByTryAgainClick);
    }
    private void OnFinishCloseByTryAgainClick() {
        _openCloseCircleController.OpenOn(Vector3.zero);
        _gameOverMenuController.Destroy();
        Controller.Invoke(GameEvent.MATCH_END);
        Controller.Invoke(GameEvent.GO_TO_JUMP_START_TUTORIAL);
        QuestionBoardStorer.Instance.QuestionBoardController.GoOutNow();
        _nextState = GameStatesStorer.Instance.Get<JumpStartTutorialGS>();
        MarkersStorer.Instance.DistanceMarkerController.ClearDistance();
        MarkersStorer.Instance.CorrectAnswersMarkerController.ClearNCorrectAnswers();
    }

    private void OnMainMenuButtonClick() {
        GameEffectSoundManager.Instance.PlayButtonClick();
        _openCloseCircleController.ClosenOn(Vector3.zero);
        _openCloseCircleController.On(OpenCloseEvent.FINISH_CLOSE, OnFinishCloseByMainMenuClick);
    }
    private void OnFinishCloseByMainMenuClick() {
        _openCloseCircleController.OpenOn(Vector3.zero);
        Controller.Invoke(GameEvent.BACK_TO_MAIN_MENU);
        Controller.Invoke(GameEvent.MATCH_END);
        _gameOverMenuController.Destroy();
        QuestionBoardStorer.Instance.QuestionBoardController.GoOutNow();
        _nextState = GameStatesStorer.Instance.Get<NoneToMainMenuGS>();
        MarkersStorer.Instance.DistanceMarkerController.ClearDistance();
        MarkersStorer.Instance.CorrectAnswersMarkerController.ClearNCorrectAnswers();
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return _nextState;
    }

    protected override void Exit() {
        _gameOverMenuController.Remove(GameOverMenuEvent.TRY_AGAIN_BUTTON_CLICK, OnTryAgainButtonClick);
        _gameOverMenuController.Remove(GameOverMenuEvent.MAIN_MENU_BUTTON_CLICK, OnMainMenuButtonClick);
        _openCloseCircleController.Remove(OpenCloseEvent.FINISH_CLOSE, OnFinishCloseByTryAgainClick);
        _openCloseCircleController.Remove(OpenCloseEvent.FINISH_CLOSE, OnFinishCloseByMainMenuClick);
    }
}
