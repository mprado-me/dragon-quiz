using UnityEngine;
using System.Collections;

public class GameBehavioursStorer : BehavioursStorer<GameBehaviour> {

    private static GameBehavioursStorer _instance;

    private GameBehavioursStorer() : base() {

    }

    public static GameBehavioursStorer Instance
    {
        get
        {
            if(_instance == null)
                _instance = new GameBehavioursStorer();

            return _instance;
        }

        set
        {
            _instance = value;
        }
    }
}