using UnityEngine;
using System.Collections;
using System;

public class DeadAirCollisionPS : PlayerState {

    protected override void Enter() {
        Controller.Add<AngleControlPB>();
        Controller.Add<FloorCollisionPB>();
        Controller.XVel = 0f;
        Controller.YVel = 0f;
        
        GameStorer.Instance.GameController.VelPlayerScenario = 0f;

        ChangeBodySprite();
    }

    private void ChangeBodySprite() {
        Data.NormalBodyGO.SetActive(false);
        Data.DeadBodyGO.SetActive(true);
    }

    protected override void Exit() {

    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        return null;
    }
}
