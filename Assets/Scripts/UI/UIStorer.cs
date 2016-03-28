using UnityEngine;
using System.Collections;

public class UIStorer {

    private MainMenuController _mainMenuController;

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
}
