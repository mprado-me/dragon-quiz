using UnityEngine;
using System.Collections;

public class DeadFloorCollisionPS : PlayerState {

    protected override void Enter() {
        Controller.XVel = 0f;
        Controller.YVel = 0f;
        Controller.GravityScale = 0f;
        Controller.AngularVel = 0f;

        GameStorer.Instance.GameController.VelPlayerScenario = 0f;
    }

    protected override void Exit() {

    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return null;
    }
}
