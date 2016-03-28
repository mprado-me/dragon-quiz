using UnityEngine;
using System.Collections;

public class DeadFloorCollisionPS : DeadPS {

    protected override void Enter() {
        base.Enter();
        Data.RigidBody.gravityScale = 0.0f;
        Data.RigidBody.angularVelocity = 0.0f;
    }

    protected override void Exit() {

    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return null;
    }
}
