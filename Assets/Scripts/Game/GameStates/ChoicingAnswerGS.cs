using UnityEngine;
using System.Collections;
using System;

public class ChoicingAnswerGS : GameState {

    protected override void Enter() {
        PlayerStorer.Instance.PlayerController.XVel = Controller.VelPlayerScenario;

        Data.UpHorizontalPipeController.On(HorizontalPipeEvent.PLAYER_ENTER, PlayerEnterInUpHorizontalPipe);
        Data.DownHorizontalPipeController.On(HorizontalPipeEvent.PLAYER_ENTER, PlayerEnterInDownHorizontalPipe);
    }

    private void PlayerEnterInUpHorizontalPipe() {
        Debug.Log("PlayerEnterInUpHorizontalPipe");
    }

    private void PlayerEnterInDownHorizontalPipe() {
        Debug.Log("PlayerEnterInDownHorizontalPipe");
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return null;
    }

    protected override void Exit() {
        Data.UpHorizontalPipeController.Remove(HorizontalPipeEvent.PLAYER_ENTER, PlayerEnterInUpHorizontalPipe);
        Data.DownHorizontalPipeController.Remove(HorizontalPipeEvent.PLAYER_ENTER, PlayerEnterInDownHorizontalPipe);
    }
}
