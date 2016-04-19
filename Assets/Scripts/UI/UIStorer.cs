using UnityEngine;
using System.Collections;

public class UIStorer {

    private MainMenuController _mainMenuController;
    private GameOverMenuController _gameOverMenuController;

    private static UIStorer _instance;

    public MainMenuController MainMenuController {
        get {
            return _mainMenuController;
        }

        set {
            _mainMenuController = value;
        }
    }

    public static UIStorer Instance {
        get {
            if(_instance == null) {
                _instance = new UIStorer();
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
