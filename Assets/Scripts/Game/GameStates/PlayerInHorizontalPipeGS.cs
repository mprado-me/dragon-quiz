using UnityEngine;
using System.Collections;
using System;

public class PlayerInHorizontalPipeGS : GameState {

    private OpenCloseCircleController _openCloseCircleController;
    private PlayerController _playerController;
    private GameState _nextState;

    protected override void Enter() {
        _nextState = null;

        Controller.VelPlayerScenario = 0f;

        _playerController = PlayerStorer.Instance.PlayerController;

        _openCloseCircleController = OpenCloseCircleStorer.Instance.OpenCloseCircleController;
        _openCloseCircleController.CloseOn(Data.HorizontalPipeEntered);
        _openCloseCircleController.On(OpenCloseEvent.FINISH_CLOSE, GoNextState);
    }

    private void GoNextState() {
        if(Data.CorrectAnswer == Data.HorizontalPipeEntered) {
            _nextState = GameStatesStorer.Instance.Get<ExitingHorizontalPipeAliveGS>();
            MarkersStorer.Instance.CorrectAnswersMarkerController.AnswerHit();
            _playerController.Invoke(PlayerEvent.GO_EXITING_ALIVE);
        }
        else {
            _nextState = GameStatesStorer.Instance.Get<ExitingHorizontalPipeDeadGS>();
            _playerController.Invoke(PlayerEvent.GO_EXITING_DEAD);
        }
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return _nextState;
    }

    protected override void Exit() {
        _openCloseCircleController.Remove(OpenCloseEvent.FINISH_CLOSE, GoNextState);
    }
}
