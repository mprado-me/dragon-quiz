using UnityEngine;
using System.Collections;
using System;

public class LaunchingHorizontalPipesGS : GameState {

    private bool _firstChoice;
    private GameState _nextGameState;

    protected override void Enter() {
        _nextGameState = null;
        _firstChoice = true;
        Controller.ClearBehaviours();
        Controller.StartCoroutine(LaunchHorizontalPipeWithDelay());
        Controller.StartCoroutine(RemoveQuestionBoardWithDelay());
        Controller.On(GameEvent.ON_HORIZONTAL_PIPE_COMPLETLY_VISIBLE, delegate {
            if(_firstChoice ) {
                _firstChoice = false;
                _nextGameState = GameStatesStorer.Instance.Get<EnterHorizontalPipeTutorialGS>();
                PlayerStorer.Instance.PlayerController.Invoke(PlayerEvent.ON_ENTER_HORIZONTAL_PIPE_TURORIAL);
            } else {
                _nextGameState = GameStatesStorer.Instance.Get<ChoicingAnswerGS>();
                PlayerStorer.Instance.PlayerController.Invoke(PlayerEvent.ON_CHOICE_ANSWER);
            }
        });
    }

    private IEnumerator LaunchHorizontalPipeWithDelay() {
        yield return new WaitForSeconds(GameSettings.Instance.delayToLaunchHorizontalPipes);
        PipesFactory.Instance.CreateUpHorizontalPipe();
        PipesFactory.Instance.CreateDownHorizontalPipe();
    }

    private IEnumerator RemoveQuestionBoardWithDelay() {
        yield return new WaitForSeconds(GameSettings.Instance.delayToRemoveQuestionBoard);
        QuestionBoardStorer.Instance.QuestionBoardController.InitOutAn();
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return _nextGameState;
    }

    protected override void Exit() {
    }
}
