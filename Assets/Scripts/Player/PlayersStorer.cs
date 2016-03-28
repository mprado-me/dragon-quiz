using UnityEngine;
using System.Collections;

public class PlayerStorer {

    private PlayerController _playerController;

    private static PlayerStorer _instance;

    public PlayerController PlayerController {
        get {
            return _playerController;
        }

        set {
            _playerController = value;
        }
    }

    public static PlayerStorer Instance {
        get {
            if( _instance == null) {
                _instance = new PlayerStorer();
            }
            return _instance;
        }
    }
}
