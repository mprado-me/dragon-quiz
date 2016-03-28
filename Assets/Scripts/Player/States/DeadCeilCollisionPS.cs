using UnityEngine;
using System.Collections;

public class DeadCeilCollisionPS : DeadPS {

    protected override void Enter() {
        base.Enter();
        Controller.Add<AngleControlPB>();
    }

    protected override void Exit() {

    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return null;
    }
}
