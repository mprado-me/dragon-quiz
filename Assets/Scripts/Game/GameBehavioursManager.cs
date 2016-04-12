using UnityEngine;
using System.Collections;

public class GameBehavioursManager : BehavioursManager<GameController, GameSettings, GameData> {

    public GameBehavioursManager(GameController gameController) : base(gameController) {
    }

    public GB Add<GB>() where GB : GameBehaviour, new() {
        return (GB) base.Add(GameBehavioursStorer.Instance.Get<GB>());
    }
}
