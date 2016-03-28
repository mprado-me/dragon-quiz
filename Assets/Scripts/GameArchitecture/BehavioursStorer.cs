using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BehavioursStorer<B> {

    private Dictionary<Type, B> _behavioursByType;

    public BehavioursStorer() {
        _behavioursByType = new Dictionary<Type, B>();
    }

    public B Get<BD>() where BD : B, new() {
        Type type = typeof(BD);
        B behaviour;
        try {
            behaviour = _behavioursByType[type];
        }
        catch(KeyNotFoundException) {
            behaviour = new BD();
            _behavioursByType[type] = behaviour;
        }
        return behaviour;
    }
}
