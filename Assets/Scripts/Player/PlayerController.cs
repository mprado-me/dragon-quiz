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

    public void Add<PB>() where PB : PlayerBehaviour, new() {
        _playerBehavioursManager.Add<PB>();
    }

    public void ClearBehaviours() {
        _playerBehavioursManager.Clear();
    }

    public void On(PlayerEvent playerEvent, UnityAction call) {
        _playerEventsManager.On(playerEvent, call);
    }

    public void Remove(PlayerEvent playerEvent, UnityAction call) {
        _playerEventsManager.Remove(playerEvent, call);
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
            return Data.AbsVel;
        }
        set {
            Data.AbsVel = value;
        }
    }
}
