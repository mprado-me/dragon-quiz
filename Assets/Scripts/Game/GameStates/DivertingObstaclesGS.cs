using UnityEngine;
using System.Collections;

public class DivertingObstaclesGS : GameState {

    private int _nPipesToLauchUntilShowQuestion;
    FixedVerticalPipesLauncherGB _fixedVerticalPipesLauncherGB;
    private GameState _nextState;

    public DivertingObstaclesGS() {
    }

    protected override void Enter() {
        _nextState = null;
        _fixedVerticalPipesLauncherGB = GameBehavioursStorer.Instance.Get<FixedVerticalPipesLauncherGB>();
        _nPipesToLauchUntilShowQuestion = Random.Range(
            Settings.minPipesLaunchedUntilShowQuestion,
            Settings.maxPipesLaunchedUntilShowQuestion);

        Controller.VelPlayerScenario = GameSettings.Instance.vel;

        MarkersStorer.Instance.DistanceMarkerController.SetActive();
        MarkersStorer.Instance.CorrectAnswersMarkerController.SetActive();

        Controller.Add<FixedVerticalPipesLauncherGB>();
        Controller.On(GameEvent.GO_GAME_OVER, GoGameOverState);
    }

    private void GoGameOverState() {
        _nextState = GameStatesStorer.Instance.Get<GameOverGS>();
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        if(_fixedVerticalPipesLauncherGB.NLauched >= _nPipesToLauchUntilShowQuestion) {
            return GameStatesStorer.Instance.Get<QuestionVisibleGS>();
        }
        return _nextState;
    }

    protected override void Exit() {
        Controller.Remove(GameEvent.GO_GAME_OVER, GoGameOverState);
    }
}