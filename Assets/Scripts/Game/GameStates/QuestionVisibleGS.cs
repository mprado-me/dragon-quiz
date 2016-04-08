using UnityEngine;

public class QuestionVisibleGS : GameState {

    private int _nPipesToLauchUntilShowQuestion;
    FixedVerticalPipesLauncherGB _fixedVerticalPipesLauncherGB;

    protected override void Enter() {
        _fixedVerticalPipesLauncherGB = GameBehavioursStorer.Instance.Get<FixedVerticalPipesLauncherGB>();
        _nPipesToLauchUntilShowQuestion = Random.Range(
            Settings.minPipesLaunchedUntilShowAnswers,
            Settings.maxPipesLaunchedUntilShowAnswers);

        Controller.Add<FixedVerticalPipesLauncherGB>();

        Data.Question = QuestionGenerator.Instance.GetNew();

        QuestionBoardController questionBoardController = QuestionBoardStorer.Instance.QuestionBoardController;
        questionBoardController.SetQuestion(Data.Question);
        questionBoardController.InitInAn();
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        if(_fixedVerticalPipesLauncherGB.NLauched >= _nPipesToLauchUntilShowQuestion) {
            return GameStatesStorer.Instance.Get<AnswersVisibleGS>();
        }
        return null;
    }

    protected override void Exit() {
    }
}
