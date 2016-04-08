using UnityEngine;
using System.Collections;

public class FloorCollisionPB : PlayerBehaviour {

    public override void Start() {
    }

    public override void Update() {

    }

    public override void OnTriggerEnter2D(Collider2D other) {
        if(other.ContainTag("Floor")) {
            Controller.State = new DeadFloorCollisionPS();
        }
    }
}
