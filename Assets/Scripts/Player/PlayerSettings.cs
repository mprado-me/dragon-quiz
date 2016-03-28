using UnityEngine;
using System.Collections;
using System;

public class PlayerSettings : Settings {
    public delegate PlayerState GetInitialStateDelegate();

    public float jumpVel = 8.0f;
    public float maxAng = 35.0f;
    public float minAng = -70.0f;
    public float controlAngUpFactor = 1.0f;
    public float controlAngDownFactor = 0.8f;
    public GetInitialStateDelegate GetInitialState = GetDefaultInitialState;

    private static PlayerSettings _instance;

    private static PlayerState GetDefaultInitialState() {
        return PlayerStatesStorer.Instance.Get<NoneToMainMenuPS>();
    }

    public static PlayerSettings Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<PlayerSettings>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
