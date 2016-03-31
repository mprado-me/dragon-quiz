using UnityEngine;
using System.Collections;
using System;

public class Mock : MonoBehaviour2 {

    private float _velPlayerScenario = 5.0f;

    private static Mock _instance;

    public float VelPlayerScenario {
        get {
            return _velPlayerScenario;
        }

        set {
            _velPlayerScenario = value;
            UpdateAbsVels();
        }
    }

    public void UpdateAbsVels() {
        PlayerController playerController = PlayerStorer.Instance.PlayerController;
        playerController.AbsVel = VelPlayerScenario * playerController.NormalizedVel;
        ScenariosManager.Instance.vel = -VelPlayerScenario * (1 - playerController.NormalizedVel);
    }

    public static Mock Instance {
        get {
            if(_instance == null) {
                _instance = GameObject.FindObjectOfType<Mock>();
            }
                
            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
