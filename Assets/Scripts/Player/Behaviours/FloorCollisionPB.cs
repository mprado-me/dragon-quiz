using UnityEngine;
using System.Collections;

public class FloorCollisionPB : PlayerBehaviour {

    public override void Start() {
        Controller.On(PlayerEvent.ON_TRIGGER_ENTER_2D, OnTriggerEnter2D);
    }

    public override void Update() {

    }

    private void OnTriggerEnter2D() {
        Collider2D other = Data.OtherCollider2D;
        if(other.ContainTag("Floor")) {
            Controller.State = new DeadFloorCollisionPS();
        }
    }

    public override void BeforeClear() {
    }
}
