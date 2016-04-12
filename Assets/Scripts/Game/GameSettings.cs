using UnityEngine;
using System.Collections;
using System;

public class GameSettings : Settings {
    public delegate GameState GetInitialStateDelegate();

    public float initMainMenuDelay = 0.3f;
    public float launchFixedVerticalPipePeriod = 2f;
    public int minPipesLaunchedUntilShowQuestion = 3;
    public int maxPipesLaunchedUntilShowQuestion = 6;
    public int minPipesLaunchedUntilShowAnswers = 2;
    public int maxPipesLaunchedUntilShowAnswers = 4;
    public int minPipesLaunchedUntilLaunchHorizontalPipes = 1;
    public int maxPipesLaunchedUntilLaunchHorizontalPipes = 3;
    public float delayToRemoveQuestionBoard = 1.0f;
    public float delayToLaunchHorizontalPipes = 3.0f;
    public float vel = 5.0f;
    public float timeToGoGameOverState = 1f;
    [SerializeField]
    private Transform inOutOpenCloseCirclePos;
    [SerializeField]
    private Transform outPlayerPos;

    public GetInitialStateDelegate GetInitialState = GetDefaultInitialState;
    private static GameState GetDefaultInitialState() {
        return GameStatesStorer.Instance.Get<NoneToMainMenuGS>();
    }

    private static GameSettings _instance;
    

    public static GameSettings Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<GameSettings>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }

    public Vector3 UpInOpenCloseCirclePos {
        get {
            return new Vector3(inOutOpenCloseCirclePos.position.x, PipesSettings.Instance.HorizontalUpY);
        }
    }

    public Vector3 DownInOpenCloseCirclePos {
        get {
            return new Vector3(inOutOpenCloseCirclePos.position.x, PipesSettings.Instance.HorizontalDownY);
        }
    }

    public Vector3 UpOutOpenCloseCirclePos {
        get {
            return new Vector3(-inOutOpenCloseCirclePos.position.x, PipesSettings.Instance.HorizontalUpY);
        }
    }

    public Vector3 DownOutOpenCloseCirclePos {
        get {
            return new Vector3(-inOutOpenCloseCirclePos.position.x, PipesSettings.Instance.HorizontalDownY);
        }
    }

    public Vector3 UpOutPlayerPos {
        get {
            return new Vector3(-outPlayerPos.position.x, PipesSettings.Instance.HorizontalUpY + outPlayerPos.localPosition.y);
        }
    }

    public Vector3 DownOutPlayerPos {
        get {
            return new Vector3(-outPlayerPos.position.x, PipesSettings.Instance.HorizontalDownY + outPlayerPos.localPosition.y);
        }
    }
}
