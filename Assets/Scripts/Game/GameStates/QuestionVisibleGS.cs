using UnityEngine;

public class QuestionVisibleGS : GameState {

    private int _nPipesToLauchUntilShowQuestion;
    FixedVerticalPipesLauncherGB _fixedVerticalPipesLauncherGB;

    protected override void Enter() {
        Controller.ClearBehaviours();
        Controller.Add<FixedVerticalPipesLauncherGB>();
        _fixedVerticalPipesLauncherGB = GameBehavioursStorer.Instance.Get<FixedVerticalPipesLauncherGB>();
        QuestionBoardController questionBoardController = QuestionBoardStorer.Instance.QuestionBoardController;
        Data.Question = QuestionGenerator.Instance.GetNew();
        questionBoardController.SetQuestion(Data.Question);
        questionBoardController.InitInAn();
        _nPipesToLauchUntilShowQuestion = Random.Range(
            Settings.minPipesLaunchedUntilShowAnswers,
            Settings.maxPipesLaunchedUntilShowAnswers);
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
