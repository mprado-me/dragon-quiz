using UnityEngine;
using System.Collections;

public abstract class Behaviour<C, S, D> where S : Settings where D : Data where C : Controller<S, D> {

    C _controller;

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

    public abstract void Start();
    public abstract void Update();
    public virtual void OnTriggerEnter2D(Collider2D other) { }
}
