using UnityEngine;
using System.Collections;
using System;

public class YUpLimitPB : PlayerBehaviour {

    public override void Start() {

    }

    public override void Update() {
        if( Controller.Y > PlayerSettings.Instance.NotJumpMoreLimitY) {
            Controller.YVel = 0f;
            Controller.Y = PlayerSettings.Instance.NotJumpMoreLimitY;
        }
    }
}
