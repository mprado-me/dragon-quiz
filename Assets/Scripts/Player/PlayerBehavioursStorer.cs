using UnityEngine;
using System.Collections;

public class PlayerBehavioursStorer : BehavioursStorer<PlayerBehaviour> {

    private static PlayerBehavioursStorer _instance;

    private PlayerBehavioursStorer() : base() {

    }

    public static PlayerBehavioursStorer Instance {
        get {
            if(_instance == null)
                _instance = new PlayerBehavioursStorer();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
