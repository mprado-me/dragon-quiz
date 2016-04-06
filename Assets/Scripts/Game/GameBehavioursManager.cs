using UnityEngine;
using System.Collections;

public class GameBehavioursManager : BehavioursManager<GameController, GameSettings, GameData> {

    public GameBehavioursManager(GameController gameController) : base(gameController) {
    }

    public void Add<GB>() where GB : GameBehaviour, new() {
        base.Add(GameBehavioursStorer.Instance.Get<GB>());
    }
}
