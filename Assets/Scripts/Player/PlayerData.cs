using UnityEngine;
using System.Collections;

public class PlayerData : Data {
    private GameObject _DeadBodyGO;
    private GameObject _NormalBodyGO;

    public GameObject DeadBodyGO {
        get {
            return _DeadBodyGO;
        }

        set {
            _DeadBodyGO = value;
        }
    }

    public GameObject NormalBodyGO {
        get {
            return _NormalBodyGO;
        }

        set {
            _NormalBodyGO = value;
        }
    }
}
