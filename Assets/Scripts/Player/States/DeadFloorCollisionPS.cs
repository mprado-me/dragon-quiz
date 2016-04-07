using UnityEngine;
using System.Collections;

public class DeadFloorCollisionPS : PlayerState {

    protected override void Enter() {
        Controller.ClearBehaviours();
        Data.RigidBody.velocity = Vector2.zero;
        Controller.Add<MoveXPlayerB>();
        Data.RigidBody.gravityScale = 0.0f;
        Data.RigidBody.angularVelocity = 0.0f;
        ScenariosManager.Instance.vel = 0.0f;
    }

    protected override void Exit() {

    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return null;
    }
}
