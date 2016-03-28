using UnityEngine;
using System.Collections;
using System;

public class CollisionPB : PlayerBehaviour {

    public override void Start() {
        Controller.On(PlayerEvent.ON_TRIGGER_ENTER_2D, OnTriggerEnter2D);
    }

    public override void Update() {

    }

    private void OnTriggerEnter2D( ) {
        Collider2D other = Data.OtherCollider2D;
        if(other.ContainTag("Floor")) {
            Controller.State = new DeadFloorCollisionPS();
        }
        else if(other.ContainTag("Ceil")) {
            Controller.State = new DeadCeilCollisionPS();
        }
    }
}
