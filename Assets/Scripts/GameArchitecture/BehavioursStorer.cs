using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BehavioursStorer<B> {

    private Dictionary<Type, B> _behavioursByType;

    public BehavioursStorer() {
        _behavioursByType = new Dictionary<Type, B>();
    }

    public BD Get<BD>() where BD : B, new() {
        Type type = typeof(BD);
        BD behaviour;
        try {
            behaviour = (BD) _behavioursByType[type];
        }
        catch(KeyNotFoundException) {
            behaviour = new BD();
            _behavioursByType[type] = behaviour;
        }
        return behaviour;
    }
}
