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
    public float gravityScale = 1.5f;
    public float wingCyclePeriod = 1f;
    public float initialX = -2f;
    public float timeToReachInitialX = 0.3f;
    public float exitHorizontalPipeYVel = 8f;
    [SerializeField]
    private Transform playerInitialTransform;
    [SerializeField]
    private Transform notJumpMoreLimitTransform;

    public GetInitialStateDelegate GetInitialState = GetDefaultInitialState;
    private static PlayerState GetDefaultInitialState() {
        return PlayerStatesStorer.Instance.Get<NoneToMainMenuPS>();
    }

    private static PlayerSettings _instance;    

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

    public Vector3 PlayerInitialPos {
        get {
            return playerInitialTransform.position;
        }
    }

    public float NotJumpMoreLimitY {
        get {
            return notJumpMoreLimitTransform.position.y;
        }
    }
}
