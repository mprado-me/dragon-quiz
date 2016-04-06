using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class BehavioursManager<C, S, D> where S : Settings where D : Data where C : Controller<S, D> {

    private C _controller;
    private Dictionary<Type, Behaviour<C, S, D> > _behavioursByType;

    public BehavioursManager(C controller) {
        _controller = controller;
        BehavioursByType = new Dictionary<Type, Behaviour<C, S, D> >();
    }

    public void Add(Behaviour<C, S, D> auxiliaryBehaviour )   {
        Type type = auxiliaryBehaviour.GetType();
        if(!BehavioursByType.ContainsKey(type)) {
            BehavioursByType.Add(type, auxiliaryBehaviour);
            auxiliaryBehaviour.Controller = _controller;
            auxiliaryBehaviour.Start();
        }
    }

    public void Clear() {
        foreach(Behaviour<C, S, D> auxiliaryBehaviour in BehavioursByType.Values) {
            auxiliaryBehaviour.Controller = _controller;
            auxiliaryBehaviour.BeforeClear();
        }
        _behavioursByType.Clear();
    }

    private Dictionary<Type, Behaviour<C, S, D>> BehavioursByType {
        get {
            return _behavioursByType;
        }
        set {
            _behavioursByType = value;
        }
    }

    public void Update() {
        foreach(Behaviour<C, S, D> auxiliaryBehaviour in BehavioursByType.Values) {
            auxiliaryBehaviour.Controller = _controller;
            auxiliaryBehaviour.Update();
        }
    }
}
