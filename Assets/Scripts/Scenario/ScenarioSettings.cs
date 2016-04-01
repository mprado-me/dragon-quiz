using UnityEngine;
using System.Collections;

public class ScenarioSettings : MonoBehaviour2 {

    public float vel = -5.0f;

    private static ScenarioSettings _instance;

    public static ScenarioSettings Instance
    {
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<ScenarioSettings>();

            return _instance;
        }

        set
        {
            _instance = value;
        }
    }
}
