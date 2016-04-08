using UnityEngine;
using System.Collections;

public class JumpPB : PlayerBehaviour {

    public override void Start() {

    }

	public override void Update () {
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) {
            Controller.YVel = Settings.jumpVel;
        }
	}
}
