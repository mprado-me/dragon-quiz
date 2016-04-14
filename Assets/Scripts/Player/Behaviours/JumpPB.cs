using UnityEngine;
using System.Collections;
using System;

public class JumpPB : PlayerBehaviour {

    private bool _missFirstCommand;
    private bool _firstCommandMissed;

    public override void Start() {
    }

	public override void Update () {
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) {
            if(_missFirstCommand && !_firstCommandMissed) {
                _firstCommandMissed = true;
                return;
            }
            Controller.YVel = Settings.jumpVel;
        }
	}

    public void missFirstJumpCommand() {
        _missFirstCommand = true;
        _firstCommandMissed = false;
    }
}
