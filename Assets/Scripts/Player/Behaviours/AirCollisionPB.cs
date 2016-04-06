using UnityEngine;
using System.Collections;
using System;

public class AirCollisionPB : PlayerBehaviour {
   
    public override void Start() {
        Controller.On(PlayerEvent.ON_TRIGGER_ENTER_2D, OnTriggerEnter2D);
    }

    public override void Update() {

    }

    private void OnTriggerEnter2D( ) {
        Collider2D other = Data.OtherCollider2D;
        if(other.ContainTag("Ceil") || other.ContainTag("PipeColl")) {
            Controller.State = new DeadAirCollisionPS();
        }
    }

    public override void BeforeClear() {
        Controller.Remove(PlayerEvent.ON_TRIGGER_ENTER_2D, OnTriggerEnter2D);
    }
}
