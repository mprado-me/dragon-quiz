using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

public class GameController : Controller<GameSettings, GameData>  {

    public string currentState;

    private GameBehavioursManager _gameBehavioursManager;
    private GameStatesManager _gameStatesManager;
    private GameEventsManager _gameEventsManager;
    private float _velPlayerScenario;

    public override void Init() {
        Settings = GameSettings.Instance;
        Data = new GameData();
        _gameEventsManager = new GameEventsManager();
        _gameBehavioursManager = new GameBehavioursManager(this);
    }

    private void Start() {
        _gameStatesManager = new GameStatesManager(this);
        QuestionBoardFactory.Instance.CreateQuestionBoard();
        OpenCloseCircleFactory.Instance.CreateOpenCloseCircle();
    }

    private void Update() {
        _gameStatesManager.Update();
        _gameBehavioursManager.Update();
        currentState = _gameStatesManager.CurrentState.GetType().Name;
    }

    public GB Add<GB>() where GB : GameBehaviour, new() {
        return _gameBehavioursManager.Add<GB>();
    }

    public override void ClearBehaviours() {
        _gameBehavioursManager.Clear();
    }

    public void On(GameEvent gameEvent, UnityAction call) {
        _gameEventsManager.On(gameEvent, call);
    }

    public void Remove(GameEvent gameEvent, UnityAction call) {
        _gameEventsManager.Remove(gameEvent, call);
    }

    public void Invoke(GameEvent gameEvent) {
        _gameEventsManager.Invoke(gameEvent);
    }

    // It is virtual to allow MockGameController override it
    public virtual float VelPlayerScenario{
        get {
            return _velPlayerScenario;
        }
        set {
            _velPlayerScenario = value;
            PlayerController playerController = PlayerStorer.Instance.PlayerController;
            ScenariosManager.Instance._DANGER_UnsafeSetVel(playerController.XVel-value);
        }
    }
}
