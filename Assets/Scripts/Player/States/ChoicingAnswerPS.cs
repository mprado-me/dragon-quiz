using UnityEngine;
using System.Collections;
using System;

public class ChoicingAnswerPS : PlayerState {

    protected override void Enter() {
        Controller.Add<JumpPB>();
        Controller.Add<AirCollisionPB>();
        Controller.Add<FloorCollisionPB>();
        Controller.Add<AngleControlPB>();
        Controller.Add<BeatWingPB>();
        Controller.GravityScale = Settings.gravityScale;
        Controller.XVel = GameSettings.Instance.vel;
    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return null;
    }

    protected override void Exit() {
    }
}
