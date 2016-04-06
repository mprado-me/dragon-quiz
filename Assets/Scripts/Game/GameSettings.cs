using UnityEngine;
using System.Collections;

public class GameSettings : Settings {
    public float initMainMenuDelay = 0.3f;
    public float launchFixedVerticalPipePeriod = 2f;
    public int minPipesLaunchedUntilShowQuestion = 3;
    public int maxPipesLaunchedUntilShowQuestion = 6;
    public int minPipesLaunchedUntilShowAnswer = 2;
    public int maxPipesLaunchedUntilShowAnswer = 4;
    public int minPipesLaunchedUntilLaunchHorizontalPipes = 1;
    public int maxPipesLaunchedUntilLaunchHorizontalPipes = 3;

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
