using UnityEngine;
using System.Collections;

public class GameStatesStorer : StatesStorer<GameState> {

    private static GameStatesStorer _instance;

    private GameStatesStorer() : base() {

    }

    public static GameStatesStorer Instance {
        get {
            if(_instance == null)
                _instance = new GameStatesStorer();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
