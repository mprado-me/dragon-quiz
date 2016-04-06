﻿using UnityEngine;
using System.Collections;
using System;

public class DivertingObstaclesPS : PlayerState {
    protected override void Enter() {
        Controller.ClearBehaviours();
        Controller.Add<JumpPB>();
        Controller.Add<AirCollisionPB>();
        Controller.Add<FloorCollisionPB>();
        Controller.Add<AngleControlPB>();
        Controller.Add<BeatWingPB>();
        Data.RigidBody.gravityScale = PlayerSettings.Instance.gravityScale;
    }

    protected override void Exit() {

    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return null;
    }
}