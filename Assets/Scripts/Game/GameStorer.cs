using UnityEngine;
using System.Collections;

public class GameStorer {

    private GameController _gameController;
    private GameData _gameData;

    private static GameStorer _instance;

    public static GameStorer Instance {
        get {
            if(_instance == null) {
                _instance = new GameStorer();
            }
            return _instance;
        }
    }

    public GameController GameController {
        get {
            return _gameController;
        }

        set {
            _gameController = value;
        }
    }

    public GameData GameData {
        get {
            return _gameData;
        }

        set {
            _gameData = value;
        }
    }
}
