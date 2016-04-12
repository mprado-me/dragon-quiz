using UnityEngine;
using System.Collections;
using System;

public class Data {
    private Type _lastType;

    public Data() {
        LastType = null;
    }

    public Type LastType {
        get {
            return _lastType;
        }

        set {
            _lastType = value;
        }
    }
}
