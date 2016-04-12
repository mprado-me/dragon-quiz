using UnityEngine;
using System.Collections;

public class ExitingHorizontalPipeDeadPS : PlayerState {

    protected override void Enter() {
        Controller.SetExitPosition(GameStorer.Instance.GameData.HorizontalPipeEntered);

        Controller.Add<AngleControlPB>();
        Controller.GravityScale = PlayerSettings.Instance.gravityScale;
        Controller.XVel = GameSettings.Instance.vel;
        Controller.YVel = PlayerSettings.Instance.exitHorizontalPipeYVel;

        Controller.OnDie();
    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return null;
    }

    protected override void Exit() {
    }
}
