using UnityEngine;

public class QuestionVisibleGS : GameState {

    private int _nPipesToLauchUntilShowQuestion;
    FixedVerticalPipesLauncherGB _fixedVerticalPipesLauncherGB;
    private GameState _nextState;

    protected override void Enter() {
        _nextState = null;
        _fixedVerticalPipesLauncherGB = GameBehavioursStorer.Instance.Get<FixedVerticalPipesLauncherGB>();
        _nPipesToLauchUntilShowQuestion = Random.Range(
            Settings.minPipesLaunchedUntilShowAnswers,
            Settings.maxPipesLaunchedUntilShowAnswers);

        Controller.Add<FixedVerticalPipesLauncherGB>();

        Data.Question = QuestionGenerator.Instance.GetNew();

        QuestionBoardController questionBoardController = QuestionBoardStorer.Instance.QuestionBoardController;
        questionBoardController.SetQuestion(Data.Question);
        questionBoardController.InitInAn();
        Controller.On(GameEvent.GO_GAME_OVER, GoGameOverState);
    }

    private void GoGameOverState() {
        _nextState = GameStatesStorer.Instance.Get<GameOverGS>();
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        if(_fixedVerticalPipesLauncherGB.NLauched >= _nPipesToLauchUntilShowQuestion) {
            return GameStatesStorer.Instance.Get<AnswersVisibleGS>();
        }
        return _nextState;
    }

    protected override void Exit() {
        Controller.Remove(GameEvent.GO_GAME_OVER, GoGameOverState);
    }
}
