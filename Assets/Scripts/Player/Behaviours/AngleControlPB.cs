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
        float k = Controller.YVel > 0 ? Settings.controlAngUpFactor : Settings.controlAngDownFactor;
        Controller.AngularVel = k * Controller.YVel * Mathf.Rad2Deg;
    }

    private void LimitAng() {
        float minAng = 360.0f + Settings.minAng;
        float ang = Controller.Ang;
        if(ang > Settings.maxAng && ang < minAng) {
            if(ang < 180)
                Controller.Ang = Settings.maxAng;
            else
                Controller.Ang = minAng;
        }
    }
}
