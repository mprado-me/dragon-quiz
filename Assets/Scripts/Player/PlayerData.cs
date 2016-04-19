using UnityEngine;
using System.Collections;

public class PlayerData : Data {
    private GameObject _deadBodyGO;
    private GameObject _normalBodyGO;

    public GameObject DeadBodyGO {
        get {
            return _deadBodyGO;
        }

        set {
            _deadBodyGO = value;
        }
    }

    public GameObject NormalBodyGO {
        get {
            return _normalBodyGO;
        }

        set {
            _normalBodyGO = value;
        }
    }
}
