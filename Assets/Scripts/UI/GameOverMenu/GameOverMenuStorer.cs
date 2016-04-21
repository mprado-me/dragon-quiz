using UnityEngine;
using System.Collections;

public class GameOverMenuStorer {

    private GameOverMenuController _gameOverMenuController;

    private static GameOverMenuStorer _instance;

    public static GameOverMenuStorer Instance {
        get {
            if(_instance == null) {
                _instance = new GameOverMenuStorer();
            }
            return _instance;
        }
    }

    public GameOverMenuController GameOverMenuController {
        get {
            return _gameOverMenuController;
        }

        set {
            _gameOverMenuController = value;
        }
    }
}
