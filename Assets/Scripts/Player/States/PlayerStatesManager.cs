using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerStatesManager : StatesManager<PlayerController, PlayerSettings, PlayerData> {

    public PlayerStatesManager(PlayerController playerController) : base(playerController) {
        CurrentState = playerController.Settings.GetInitialState();
    }
}
