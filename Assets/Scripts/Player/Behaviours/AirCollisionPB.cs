using UnityEngine;
using System.Collections;
using System;

public class AirCollisionPB : PlayerBehaviour {
   
    public override void Start() {
    }

    public override void Update() {
    }

    public override void OnTriggerEnter2D(Collider2D other) {
        if(other.ContainTag("Ceil") || other.ContainTag("PipeColl")) {
            PlayerEffectSoundManager.Instance.PlayColl();
            Controller.State = new DeadAirCollisionPS();
        }
    }
}
