using UnityEngine;
using System.Collections;
using System;

public class LaunchingHorizontalPipesGS : GameState {

    private bool _firstChoice;
    private GameState _nextState;

    protected override void Enter() {
        _nextState = null;
        _firstChoice = true;

        Controller.StartCoroutine(LaunchHorizontalPipeWithDelay());
        Controller.StartCoroutine(RemoveQuestionBoardWithDelay());

        Controller.On(GameEvent.HORIZONTAL_PIPE_COMPLETLY_VISIBLE, GoNextState);
    }

    private void GoNextState() {
        if(_firstChoice) {
            _firstChoice = false;
            _nextState = GameStatesStorer.Instance.Get<EnterHorizontalPipeTutorialGS>();
            PlayerStorer.Instance.PlayerController.Invoke(PlayerEvent.GO_ENTER_HORIZONTAL_PIPE_TURORIAL);
        }
        else {
            _nextState = GameStatesStorer.Instance.Get<ChoicingAnswerGS>();
            PlayerStorer.Instance.PlayerController.Invoke(PlayerEvent.GO_CHOICE_ANSWER);
        }
    }

    private IEnumerator LaunchHorizontalPipeWithDelay() {
        yield return new WaitForSeconds(Settings.delayToLaunchHorizontalPipes);
        Data.UpHorizontalPipeController = PipesFactory.Instance.CreateUpHorizontalPipe();
        Data.DownHorizontalPipeController = PipesFactory.Instance.CreateDownHorizontalPipe();
    }

    private IEnumerator RemoveQuestionBoardWithDelay() {
        yield return new WaitForSeconds(Settings.delayToRemoveQuestionBoard);
        QuestionBoardStorer.Instance.QuestionBoardController.InitOutAn();
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return _nextState;
    }

    protected override void Exit() {
        Controller.Remove(GameEvent.HORIZONTAL_PIPE_COMPLETLY_VISIBLE, GoNextState);
    }
}
