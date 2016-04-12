using UnityEngine;

public class AnswersVisibleGS : GameState {

    private int _nPipesToLauchUntilShowQuestion;
    FixedVerticalPipesLauncherGB _fixedVerticalPipesLauncherGB;
    private GameState _nextState;

    protected override void Enter() {
        _nextState = null;
        _fixedVerticalPipesLauncherGB = GameBehavioursStorer.Instance.Get<FixedVerticalPipesLauncherGB>();
        _nPipesToLauchUntilShowQuestion = Random.Range(
            Settings.minPipesLaunchedUntilLaunchHorizontalPipes,
            Settings.maxPipesLaunchedUntilLaunchHorizontalPipes);

        Controller.Add<FixedVerticalPipesLauncherGB>();

        if( Random.Range(0, 2) == 0) {
            AnswersFactory.Instance.CreateUp(Data.Question.correctAnswerType, Data.Question.correctAnswerContent);
            AnswersFactory.Instance.CreateDown(Data.Question.incorrectAnswerType, Data.Question.incorrectAnswerContent);
            Data.CorrectAnswer = HorizontalPipe.UP;
        } else {
            AnswersFactory.Instance.CreateUp(Data.Question.incorrectAnswerType, Data.Question.incorrectAnswerContent);
            AnswersFactory.Instance.CreateDown(Data.Question.correctAnswerType, Data.Question.correctAnswerContent);
            Data.CorrectAnswer = HorizontalPipe.DOWN;
        }

        Controller.On(GameEvent.GO_GAME_OVER, GoGameOverState);
    }

    private void GoGameOverState() {
        _nextState = GameStatesStorer.Instance.Get<GameOverGS>();
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        if(_fixedVerticalPipesLauncherGB.NLauched >= _nPipesToLauchUntilShowQuestion) {
            return GameStatesStorer.Instance.Get<LaunchingHorizontalPipesGS>();
        }
        return null;
    }

    protected override void Exit() {
        Controller.Remove(GameEvent.GO_GAME_OVER, GoGameOverState);
    }
}
