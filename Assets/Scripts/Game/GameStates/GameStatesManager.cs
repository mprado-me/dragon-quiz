using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameStatesManager : StatesManager<GameController, GameSettings, GameData> {

    public GameStatesManager(GameController gameController) : base(gameController) {
        CurrentState = GameStatesStorer.Instance.Get<NoneToMainMenuGS>();
    }
}