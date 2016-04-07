using UnityEngine;
using System.Collections;

public class DeadAirCollisionPS : PlayerState {

    protected override void Enter() {
        Controller.ClearBehaviours();
        Data.RigidBody.velocity = Vector2.zero;
        Controller.Add<MoveXPlayerB>();
        Controller.Add<AngleControlPB>();
        Controller.Add<FloorCollisionPB>();
        ScenariosManager.Instance.vel = 0.0f;
    }

    protected override void Exit() {

    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return null;
    }
}
