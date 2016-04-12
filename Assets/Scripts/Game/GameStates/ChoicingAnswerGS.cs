using UnityEngine;
using System.Collections;
using System;

public class ChoicingAnswerGS : GameState {

    private GameState _nextState;

    protected override void Enter() {
        _nextState = null;

        Data.UpHorizontalPipeController.On(HorizontalPipeEvent.PLAYER_ENTER, PlayerEnterInUpHorizontalPipe);
        Data.DownHorizontalPipeController.On(HorizontalPipeEvent.PLAYER_ENTER, PlayerEnterInDownHorizontalPipe);
        Controller.On(GameEvent.GO_GAME_OVER, GoGameOverState);
    }

    private void GoGameOverState() {
        _nextState = GameStatesStorer.Instance.Get<GameOverGS>();
    }

    private void PlayerEnterInUpHorizontalPipe() {
        _nextState = GameStatesStorer.Instance.Get<PlayerInHorizontalPipeGS>();
        Controller.Invoke(GameEvent.PLAYER_IN_HORIZONTAL_PIPE);
        Data.HorizontalPipeEntered = HorizontalPipe.UP;
    }

    private void PlayerEnterInDownHorizontalPipe() {
        _nextState = GameStatesStorer.Instance.Get<PlayerInHorizontalPipeGS>();
        Controller.Invoke(GameEvent.PLAYER_IN_HORIZONTAL_PIPE);
        Data.HorizontalPipeEntered = HorizontalPipe.DOWN;
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return _nextState;
    }

    protected override void Exit() {
        Data.UpHorizontalPipeController.Remove(HorizontalPipeEvent.PLAYER_ENTER, PlayerEnterInUpHorizontalPipe);
        Data.DownHorizontalPipeController.Remove(HorizontalPipeEvent.PLAYER_ENTER, PlayerEnterInDownHorizontalPipe);
        Controller.Remove(GameEvent.GO_GAME_OVER, GoGameOverState);
    }
}
