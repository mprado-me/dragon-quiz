using UnityEngine;
using System.Collections;
using System;

public class LaunchingHorizontalPipesGS : GameState {

    private bool _firstChoice;
    private GameState _nextState;
    private float _delta0, _delta1;
    private bool _triggered0, _triggered1; 

    protected override void Enter() {
        _nextState = null;
        _firstChoice = true;
        _delta0 = 0f;
        _delta1 = 0f;
        _triggered0 = false;
        _triggered1 = false;

        Controller.On(GameEvent.HORIZONTAL_PIPE_COMPLETLY_VISIBLE, GoNextState);
        Controller.On(GameEvent.GO_GAME_OVER, GoGameOverState);
    }

    private void GoNextState() {
        if(_firstChoice) {
            _firstChoice = false;
            _nextState = GameStatesStorer.Instance.Get<EnterHorizontalPipeTutorialGS>();
            PlayerStorer.Instance.PlayerController.Invoke(PlayerEvent.GO_ENTER_HORIZONTAL_PIPE_TUTORIAL);
        }
        else {
            _nextState = GameStatesStorer.Instance.Get<ChoicingAnswerGS>();
            PlayerStorer.Instance.PlayerController.Invoke(PlayerEvent.GO_CHOICE_ANSWER);
        }
    }

    private void GoGameOverState() {
        _nextState = GameStatesStorer.Instance.Get<GameOverGS>();
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        _delta0 += Time.deltaTime;
        _delta1 += Time.deltaTime;
        if( _delta0 > Settings.delayToLaunchHorizontalPipes && !_triggered0) {
            _triggered0 = true;
            Data.UpHorizontalPipeController = PipesFactory.Instance.CreateUpHorizontalPipe();
            Data.DownHorizontalPipeController = PipesFactory.Instance.CreateDownHorizontalPipe();
        }
        if(_delta1 > Settings.delayToRemoveQuestionBoard && !_triggered1) {
            _triggered1 = true;
            QuestionBoardStorer.Instance.QuestionBoardController.InitOutAn();
        }
        return _nextState;
    }

    protected override void Exit() {
        Controller.Remove(GameEvent.HORIZONTAL_PIPE_COMPLETLY_VISIBLE, GoNextState);
        Controller.Remove(GameEvent.GO_GAME_OVER, GoGameOverState);
    }
}
