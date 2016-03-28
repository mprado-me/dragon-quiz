using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerStatesStorer : StatesStorer<PlayerState> {

    private static PlayerStatesStorer _instance;

    private PlayerStatesStorer() : base() {

    }

    public static PlayerStatesStorer Instance {
        get {
            if(_instance == null)
                _instance = new PlayerStatesStorer();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
