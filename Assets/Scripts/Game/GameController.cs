using UnityEngine;
using System.Collections;
using System;

public class GameController : Controller<GameSettings, GameData> {

    private GameStatesManager _gameStatesManager;

    private void Start() {
        InitGameStatesManager();
    }

    private void InitGameStatesManager() {
        _gameStatesManager = new GameStatesManager(this);
    }

    private void Update() {
        _gameStatesManager.Update();
    }
}
