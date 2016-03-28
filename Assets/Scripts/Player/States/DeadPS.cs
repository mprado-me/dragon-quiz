using UnityEngine;
using System.Collections;
using System;

public abstract class DeadPS : PlayerState {

    protected override void Enter() {
        Debug.Log("Player died!");
        Controller.ClearBehaviours();
        Data.RigidBody.velocity = Vector2.zero;
        Controller.Add<XMovePB>();
        Mock.Instance.VelPlayerScenario = 0.0f;
    }
}
