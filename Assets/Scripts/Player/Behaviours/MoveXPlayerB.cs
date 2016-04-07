using UnityEngine;
using System.Collections;
using System;

public class MoveXPlayerB : PlayerBehaviour {

    public override void Start() {
    }

    public override void Update() {
        //Debug.Log("MoveXPlayerB.Update()");
        //Debug.Log("Data.AbsVel: " + Data.AbsVel);
        Data.RigidBody.velocity = new Vector2(Data.AbsVel, Data.RigidBody.velocity.y);
    }

    public override void BeforeClear() {
    }
}
