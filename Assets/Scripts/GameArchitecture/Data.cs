using UnityEngine;
using System.Collections;
using System;

public class Data {
    private Type _lastStateType;

    public Data() {
        LastStateType = null;
    }

    public Type LastStateType {
        get {
            return _lastStateType;
        }

        set {
            _lastStateType = value;
        }
    }
}
