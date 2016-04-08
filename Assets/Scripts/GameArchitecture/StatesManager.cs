using UnityEngine;
using System.Collections;

public class StatesManager<C, S, D> where S : Settings where D : Data where C : Controller<S, D> {

    protected State<C, S, D> _currentState;
    private C _controller;

    public StatesManager(C controller) {
        _controller = controller;
    }

    public void Update() {
        State<C, S, D> nextState = CurrentState.SetControllerAndUpdate(_controller);
        if(nextState != null) {
            CurrentState = nextState;
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        CurrentState.OnTriggerEnter2D(other);
    }

    public State<C, S, D> CurrentState {
        get {
            return _currentState;
        }
        set {
            if(_currentState != null)
                _currentState.SetControllerAndExit(_controller);
            _currentState = value;
            if(value != null) {
                _currentState.SetControllerClearBehavioursAndEnter(_controller);
            }
        }
    }
}
