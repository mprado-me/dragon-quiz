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

        _gameOverMenuController = UIFactory.Instance.CreateGameOverMenu(
            Data.NCorrectAnswers,
            Data.NCorrectAnswers > Data.NCorrectAnswersRecord,
            Data.NCorrectAnswersRecord,
            Data.Distance,
            Data.Distance > Data.DistanceRecord,
            Data.DistanceRecord);

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
