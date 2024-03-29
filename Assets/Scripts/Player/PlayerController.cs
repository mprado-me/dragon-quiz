﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

public class PlayerController : Controller<PlayerSettings, PlayerData> {

    // Debug
    public string currentState;

    private Rigidbody2D _rb;

    private PlayerBehavioursManager _playerBehavioursManager;
    private PlayerStatesManager _playerStatesManager;
    private PlayerEventsManager _playerEventsManager;

    public override void Init() {
        Settings = PlayerSettings.Instance;
        Data = new PlayerData();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        _playerEventsManager = new PlayerEventsManager();
        _playerBehavioursManager = new PlayerBehavioursManager(this);
        _playerStatesManager = new PlayerStatesManager(this);
        Position = PlayerSettings.Instance.PlayerInitialPos;
    }

    private void Update() {
        _playerStatesManager.Update();
        _playerBehavioursManager.Update();
        DebugUpdate();
    }

    private void DebugUpdate() {
        currentState = _playerStatesManager.CurrentState.GetType().Name;
    }

    public PB Add<PB>() where PB : PlayerBehaviour, new() {
        return _playerBehavioursManager.Add<PB>();
    }

    public override void ClearBehaviours() {
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

    public void OnTriggerEnter2D(Collider2D other) {
        _playerBehavioursManager.OnTriggerEnter2D(other);
        _playerStatesManager.OnTriggerEnter2D(other);
    }

    public State<PlayerController, PlayerSettings, PlayerData> State {
        get {
            return _playerStatesManager.CurrentState;
        }
        set {
            _playerStatesManager.CurrentState = value;
        }
    }

    public void _DANGER_UnsafeSetXVel(float xVel) {
        _rb.velocity = new Vector2(xVel, _rb.velocity.y);
    }

    public void SetExitPosition(HorizontalPipe horizontalPipeEntered) {
        if(horizontalPipeEntered == HorizontalPipe.UP)
            Position = GameSettings.Instance.UpOutPlayerPos;
        else
            Position = GameSettings.Instance.DownOutPlayerPos;
    }

    public void OnDie() {
        Data.NormalBodyGO.SetActive(false);
        Data.DeadBodyGO.SetActive(true);
    }

    public void OnLive() {
        Data.NormalBodyGO.SetActive(true);
        Data.DeadBodyGO.SetActive(false);
    }

    public float XVel {
        get {
            return _rb.velocity.x;
        }
        set {
            _rb.velocity = new Vector2(value, _rb.velocity.y);
            ScenariosManager.Instance._DANGER_UnsafeSetVel(value - GameStorer.Instance.GameController.VelPlayerScenario);
        }
    }

    public float YVel {
        get {
            return _rb.velocity.y;
        }
        set {
            _rb.velocity = new Vector2(_rb.velocity.x, value);
        }
    }

    public float AngVel {
        get {
            return _rb.angularVelocity;
        }
        set {
            _rb.angularVelocity = value;
        }
    }

    public float GravityScale {
        get {
            return _rb.gravityScale;
        }
        set {
            _rb.gravityScale = value;
        }
    }

    public float Ang {
        get {
            return transform.localEulerAngles.z;
        }
        set {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, value);
        }
    }

    public float X {
        get {
            return transform.position.x;
        }
        set {
            transform.position = new Vector3(value, transform.position.y, transform.position.z);
        }
    }

    public float Y {
        get {
            return transform.position.y;
        }
        set {
            transform.position = new Vector3(transform.position.x, value, transform.position.z);
        }
    }

    public Vector3 Position {
        get {
            return transform.position;
        }
        set {
            transform.position = value;
        }
    }
}
