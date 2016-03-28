using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class StatesStorer<S> {

    private Dictionary<Type, S> _statesByType;

    public StatesStorer() {
        _statesByType = new Dictionary<Type, S>();
    }

    public S Get<T>() where T : S, new() {
        Type type = typeof(T);
        S state;
        try {
            state = _statesByType[type];
        }
        catch(KeyNotFoundException) {
            state = new T();
            _statesByType[type] = state;
        }
        return state;
    }
}
