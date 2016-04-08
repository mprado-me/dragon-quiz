using UnityEngine;
using System.Collections;

public class MockGameController : GameController {

    private float _velPlayerScenario;

    void Start () {
	
	}
	
	void Update () {
	
	}

    public override float VelPlayerScenario {
        get {
            return _velPlayerScenario;
        }
        set {
            _velPlayerScenario = value;
        }
    }
}
