using UnityEngine;
using System.Collections;
using System;

public class XMovePB : PlayerBehaviour {

    public override void Start() {
    }

    public override void Update() {
        Data.RigidBody.velocity = new Vector2(Data.AbsVel, Data.RigidBody.velocity.y);
    }

    public override void BeforeClear() {
    }
}
