using UnityEngine;
using System.Collections;
using System;

public class PlayerBehavioursManager : BehavioursManager<PlayerController, PlayerSettings, PlayerData> {

    public PlayerBehavioursManager(PlayerController playerController) : base(playerController) {
    }

    public PB Add<PB>() where PB : PlayerBehaviour, new() {
        PB pb = PlayerBehavioursStorer.Instance.Get<PB>();
        base.Add(pb);
        return pb;
    }
}
