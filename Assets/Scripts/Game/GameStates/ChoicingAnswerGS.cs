﻿using UnityEngine;
using System.Collections;
using System;

public class ChoicingAnswerGS : GameState {

    protected override void Enter() {
        PlayerStorer.Instance.PlayerController.XVel = Controller.VelPlayerScenario;
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return null;
    }

    protected override void Exit() {
    }
}
