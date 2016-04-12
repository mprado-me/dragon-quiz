using UnityEngine;
using System.Collections;
using System;

public class FixedVerticalPipesLauncherGB : GameBehaviour {

    private int _nLauched;
    private float _delta;

    public FixedVerticalPipesLauncherGB() {
    }

    public override void Start() {
        _nLauched = 0;
        _delta = 0f;
    }

    public override void Update() {
        _delta += Time.deltaTime;
        if(_delta >= Settings.launchFixedVerticalPipePeriod) {
            _nLauched++;
            _delta = 0.0f;
            PipesFactory.Instance.CreateFixedVerticalPipe();
        }
    }

    public void ClearNLauched() {
        _nLauched = 0;
    }

    public int NLauched {
        get {
            return _nLauched;
        }
    }

    public void AdvancedLaunch(float advancedTime) {
        FixedVerticalPipeController fixedVerticalPipeController = PipesFactory.Instance.CreateFixedVerticalPipe();
        fixedVerticalPipeController.transform.localPosition = new Vector3(
            fixedVerticalPipeController.transform.localPosition.x - advancedTime*Controller.VelPlayerScenario,
            fixedVerticalPipeController.transform.localPosition.y);
    }
}
