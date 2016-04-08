using UnityEngine;
using System.Collections;

public abstract class State<C, S, D> where S : Settings where D : Data where C : Controller<S, D> {

    C _controller;

    public void SetControllerClearBehavioursAndEnter(C controller) {
        Controller = controller;
        Controller.ClearBehaviours();
        Enter();
    }

    public State<C, S, D> SetControllerAndUpdate(C controller) {
        Controller = controller;
        return Update();
    }

    public void SetControllerAndExit(C controller) {
        Controller = controller;
        Exit();
    }

    protected abstract void Enter();
    protected abstract State<C, S, D> Update();
    protected abstract void Exit();
    public virtual void OnTriggerEnter2D(Collider2D other) {}

    // It need be public? Or can be protected
    public C Controller {
        get {
            return _controller;
        }
            
        set {
            _controller = value;
        }
    }

    protected S Settings {
        get {
            return Controller.Settings;
        }
    }

    protected D Data {
        get {
            return Controller.Data;
        }
    }
}
