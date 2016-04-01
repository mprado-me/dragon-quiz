using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

public class GameController : Controller<GameSettings, GameData> {

    public string currentState;

    private GameStatesManager _gameStatesManager;
    private GameEventsManager _gameEventsManager;

    private void Start() {
        InitGameStatesManager();
        QuestionBoardFactory.Instance.CreateQuestionBoard();
        _gameEventsManager = new GameEventsManager();
    }

    private void InitGameStatesManager() {
        _gameStatesManager = new GameStatesManager(this);
    }

    private void Update() {
        _gameStatesManager.Update();
        currentState = _gameStatesManager.CurrentState.GetType().Name;
    }

    public void On(GameEvent gameEvent, UnityAction call) {
        _gameEventsManager.On(gameEvent, call);
    }

    public void Invoke(GameEvent gameEvent) {
        _gameEventsManager.Invoke(gameEvent);
    }
}
