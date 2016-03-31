using UnityEngine;
using System.Collections;

public class GameSettings : Settings {
    public float initMainMenuDelay = 0.3f;
    public float launchFixedVerticalPipePeriod = 2f;

    private static GameSettings _instance;

    public static GameSettings Instance
    {
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<GameSettings>();

            return _instance;
        }

        set
        {
            _instance = value;
        }
    }
}
