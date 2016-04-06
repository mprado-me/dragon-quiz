using UnityEngine;
using System.Collections;
using System;

public class FixedVerticalPipesLauncherGB : GameBehaviour {

    private int _nLauched;
    private float _delta;

    public override void Start() {
        _nLauched = 0;
        _delta = 0.0f;
    }

    public override void Update() {
        _delta += Time.deltaTime;
        if(_delta >= GameSettings.Instance.launchFixedVerticalPipePeriod) {
            _nLauched++;
            _delta = 0.0f;
            PipesFactory.Instance.CreateFixedVerticalPipe();
        }
    }

    public override void BeforeClear() {
    }

    public void ClearNLauched() {
        _nLauched = 0;
    }

    public int NLauched {
        get {
            return _nLauched;
        }
    }
}
