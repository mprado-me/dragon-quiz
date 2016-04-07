using UnityEngine;
using System.Collections;
using System;

public class ChoicingAnswerPS : PlayerState {

    protected override void Enter() {
        Controller.ClearBehaviours();
        Controller.Add<MoveXPlayerB>();
        Controller.Add<JumpPB>();
        Controller.Add<AirCollisionPB>();
        Controller.Add<FloorCollisionPB>();
        Controller.Add<AngleControlPB>();
        Controller.Add<BeatWingPB>();
        Data.RigidBody.gravityScale = PlayerSettings.Instance.gravityScale;
        Data.AbsVel = -ScenarioSettings.Instance.vel;
    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return null;
    }

    protected override void Exit() {
    }
}
