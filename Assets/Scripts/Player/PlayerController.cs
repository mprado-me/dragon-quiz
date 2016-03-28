using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

public class PlayerController : Controller<PlayerSettings, PlayerData> {

    // Debug
    public string currentState;

    private PlayerBehavioursManager _playerBehavioursManager;
    private PlayerStatesManager _playerStatesManager;
    private PlayerEventsManager _playerEventsManager;

    private void Start() {
        Settings = PlayerSettings.Instance;
        Data = new PlayerData(this);
        _playerEventsManager = new PlayerEventsManager();
        _playerBehavioursManager = new PlayerBehavioursManager(this);
        _playerStatesManager = new PlayerStatesManager(this);
    }

    private void Update() {
        _playerStatesManager.Update();
        _playerBehavioursManager.Update();
        DebugUpdate();
    }

    private void DebugUpdate() {
        currentState = _playerStatesManager.CurrentState.GetType().Name;
    }

    public void Add<PAB>() where PAB : PlayerBehaviour, new() {
        _playerBehavioursManager.Add<PAB>();
    }

    public void ClearBehaviours() {
        _playerBehavioursManager.Clear();
    }

    public void On(PlayerEvent playerEvent, UnityAction call) {
        _playerEventsManager.On(playerEvent, call);
    }

    public void Invoke(PlayerEvent playerEvent) {
        _playerEventsManager.Invoke(playerEvent);
    }

    public void OnTriggerEnter2D( Collider2D other) {
        Data.OtherCollider2D = other;
        Invoke(PlayerEvent.ON_TRIGGER_ENTER_2D);
    }

    public State<PlayerController, PlayerSettings, PlayerData> State {
        get {
            return _playerStatesManager.CurrentState;
        }
        set {
            _playerStatesManager.CurrentState = value;
        }
    }

    public float NormalizedVel {
        get {
            //return refs.normalizedVel;
            return 0.0f;
        }
        set {
            //refs.normalizedVel = value;
            //Mock.Instance.UpdateAbsVels();
        }
    }

    public float AbsVel {
        get {
            //return refs.absVel;
            return 0.0f;
        }
        set {
            //refs.absVel = value;
        }
    }
}
