using UnityEngine;
using System.Collections;

public class GameStorer {

    private GameController _gameController;

    private static GameStorer _instance;

    public GameController GameController
    {
        get
        {
            return _gameController;
        }

        set
        {
            _gameController = value;
        }
    }

    public static GameStorer Instance
    {
        get
        {
            if(_instance == null) {
                _instance = new GameStorer();
            }
            return _instance;
        }
    }
}
