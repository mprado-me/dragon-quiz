using UnityEngine;
using System.Collections;
using System;

public class AngleControlPB : PlayerBehaviour {

    public override void Start() {

    }

    public override void Update() {
        UpdateAngVel();
        LimitAng();
    }

    private void UpdateAngVel() {
        float k = Data.RigidBody.velocity.y > 0 ? Settings.controlAngUpFactor : Settings.controlAngDownFactor;
        Data.RigidBody.angularVelocity = k * Data.RigidBody.velocity.y * Mathf.Rad2Deg;
    }

    private void LimitAng() {
        float minAng = 360.0f + Settings.minAng;
        float ang = Data.Transform.localEulerAngles.z;
        if(ang > Settings.maxAng && ang < minAng) {
            if(ang < 180)
                Data.Transform.localEulerAngles = Vector3.forward * Settings.maxAng;
            else
                Data.Transform.localEulerAngles = Vector3.forward * minAng;
        }
    }
}
