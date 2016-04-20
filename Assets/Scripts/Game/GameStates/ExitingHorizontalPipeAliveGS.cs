using UnityEngine;
using System.Collections;
using System;

public class ExitingHorizontalPipeAliveGS : GameState {

    private GameState _nextState;

    protected override void Enter() {
        _nextState = null;

        Controller.VelPlayerScenario = Settings.vel;

        OpenCloseCircleStorer.Instance.OpenCloseCircleController.OpenOn(Data.HorizontalPipeEntered);

        FixedVerticalPipesLauncherGB fixedVerticalPipesLauncherGB = Controller.Add<FixedVerticalPipesLauncherGB>();
        fixedVerticalPipesLauncherGB.AdvancedLaunch(0f);
        fixedVerticalPipesLauncherGB.AdvancedLaunch(GameSettings.Instance.launchFixedVerticalPipePeriod);

        Controller.On(GameEvent.PLAYER_BACK_TO_DIVERT_OSBTACLE_STATE, GoNextState);
        Controller.Invoke(GameEvent.EXITING_HORIZONTAL_PIPE_START);

        GameEffectSoundManager.Instance.PlayHitQuestion();
    }

    private void GoNextState() {
        _nextState = GameStatesStorer.Instance.Get<DivertingObstaclesGS>();
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return _nextState;
    }

    protected override void Exit() {
        Controller.Remove(GameEvent.PLAYER_BACK_TO_DIVERT_OSBTACLE_STATE, GoNextState);
    }
}
