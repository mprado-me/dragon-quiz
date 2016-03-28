using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ScenarioType {
    NONE,
    SKY,
    GROUND,
    CAVE
}

public class ScenariosManager : MonoBehaviour2{

    public float absVel; // The signal is inside vel;

    private Dictionary<ScenarioType, GameObject> scenariosDict;
    private ScenarioType _current;

    private static ScenariosManager _instance;

    private void Init() {
        _instance = this;
        scenariosDict = new Dictionary<ScenarioType, GameObject>();
        scenariosDict.Add(ScenarioType.SKY, ScenariosFactory.Instance.CreateSky());
        scenariosDict.Add(ScenarioType.GROUND, ScenariosFactory.Instance.CreateGround());
        scenariosDict.Add(ScenarioType.CAVE, ScenariosFactory.Instance.CreateCave());
        _current = ScenarioType.NONE;
    }

    public ScenarioType Current {
        get {
            return _current;
        }
        set {
            if(_current != ScenarioType.NONE)
                scenariosDict[_current].SetActive(false);

            scenariosDict[value].SetActive(true);
            _current = value;
        }
    }

    public static ScenariosManager Instance {
        get {
            if(_instance == null) {
                _instance = GameObject.FindObjectOfType<ScenariosManager>();
                _instance.Init();
            }

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
