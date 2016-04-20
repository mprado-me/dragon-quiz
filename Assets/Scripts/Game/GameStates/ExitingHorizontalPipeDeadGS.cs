using UnityEngine;
using System.Collections;
using System;

public class ExitingHorizontalPipeDeadGS : GameState {

    private float _delta;

    protected override void Enter() {
        _delta = 0f;

        Controller.VelPlayerScenario = Settings.vel;

        OpenCloseCircleStorer.Instance.OpenCloseCircleController.OpenOn(Data.HorizontalPipeEntered);

        Controller.Invoke(GameEvent.EXITING_HORIZONTAL_PIPE_START);

        GameEffectSoundManager.Instance.PlayMissQuestion();
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        _delta += Time.deltaTime;
        if(_delta > GameSettings.Instance.timeToGoGameOverState)
            return GameStatesStorer.Instance.Get<GameOverGS>();
        return null;
    }

    protected override void Exit() {
    }
}
