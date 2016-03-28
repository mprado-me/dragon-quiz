using UnityEngine;
using System.Collections;
using System;

public class DivertingVerticalPipesPS : PlayerState {
    protected override void Enter() {
        Controller.ClearBehaviours();
        Controller.Add<JumpPB>();
        Controller.Add<CollisionPB>();
        Controller.Add<AngleControlPB>();
    }

    protected override void Exit() {

    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return null;
    }
}
