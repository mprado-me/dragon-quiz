using UnityEngine;
using System.Collections;

public class DivertingObstaclesGS : GameState {

    private int _nPipesToLauchUntilShowQuestion;
    FixedVerticalPipesLauncherGB _fixedVerticalPipesLauncherGB;

    public DivertingObstaclesGS() {
    }

    protected override void Enter() {
        Controller.ClearBehaviours();
        Controller.Add<FixedVerticalPipesLauncherGB>();
        _fixedVerticalPipesLauncherGB = GameBehavioursStorer.Instance.Get<FixedVerticalPipesLauncherGB>();
        _nPipesToLauchUntilShowQuestion = Random.Range(
            Settings.minPipesLaunchedUntilShowQuestion,
            Settings.maxPipesLaunchedUntilShowQuestion);
        ScenariosManager.Instance.vel = ScenarioSettings.Instance.vel;
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