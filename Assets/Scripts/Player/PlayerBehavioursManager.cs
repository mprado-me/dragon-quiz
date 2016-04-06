using UnityEngine;
using System.Collections;
using System;

public class PlayerBehavioursManager : BehavioursManager<PlayerController, PlayerSettings, PlayerData> {

    public PlayerBehavioursManager(PlayerController playerController) : base(playerController) {
    }

    public void Add<PB>() where PB : PlayerBehaviour, new() {
        base.Add(PlayerBehavioursStorer.Instance.Get<PB>());
    }
}
