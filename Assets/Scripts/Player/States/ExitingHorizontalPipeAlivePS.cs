using UnityEngine;
using System.Collections;

public class ExitingHorizontalPipeAlivePS : PlayerState {

    protected override void Enter() {
        Controller.SetExitPosition(GameStorer.Instance.GameData.HorizontalPipeEntered);

        Controller.Add<JumpPB>();
        Controller.Add<AirCollisionPB>();
        Controller.Add<FloorCollisionPB>();
        Controller.Add<AngleControlPB>();
        Controller.Add<BeatWingPB>();
        Controller.GravityScale = PlayerSettings.Instance.gravityScale;
        Controller.XVel = GameSettings.Instance.vel;
        Controller.YVel = PlayerSettings.Instance.exitHorizontalPipeYVel;
    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return null;
    }

    protected override void Exit() {
    }
}
