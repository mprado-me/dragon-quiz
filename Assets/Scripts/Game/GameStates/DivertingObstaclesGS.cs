using UnityEngine;
using System.Collections;

public class DivertingObstaclesGS : GameState {

    private int _nPipesToLauchUntilShowQuestion;
    FixedVerticalPipesLauncherGB _fixedVerticalPipesLauncherGB;

    public DivertingObstaclesGS() {
    }

    protected override void Enter() {
        ScenariosManager.Instance.vel = ScenarioSettings.Instance.vel;
        Controller.Add<FixedVerticalPipesLauncherGB>();
        _fixedVerticalPipesLauncherGB = GameBehavioursStorer.Instance.Get<FixedVerticalPipesLauncherGB>();
        _nPipesToLauchUntilShowQuestion = Random.Range(
            GameSettings.Instance.minPipesLaunchedUntilShowQuestion,
            GameSettings.Instance.maxPipesLaunchedUntilShowQuestion);
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        if(_fixedVerticalPipesLauncherGB.NLauched >= _nPipesToLauchUntilShowQuestion) {
            return GameStatesStorer.Instance.Get<QuestionVisibleGS>();
        }
        return null;
    }

    protected override void Exit() {

    }
}