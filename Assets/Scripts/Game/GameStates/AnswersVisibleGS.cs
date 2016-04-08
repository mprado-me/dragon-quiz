using UnityEngine;

public class AnswersVisibleGS : GameState {

    private int _nPipesToLauchUntilShowQuestion;
    FixedVerticalPipesLauncherGB _fixedVerticalPipesLauncherGB;

    protected override void Enter() {
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
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        if(_fixedVerticalPipesLauncherGB.NLauched >= _nPipesToLauchUntilShowQuestion) {
            return GameStatesStorer.Instance.Get<LaunchingHorizontalPipesGS>();
        }
        return null;
    }

    protected override void Exit() {
    }
}
