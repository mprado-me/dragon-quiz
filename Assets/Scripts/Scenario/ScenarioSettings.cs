using UnityEngine;
using System.Collections;

public class ScenarioSettings : MonoBehaviour2 {

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
