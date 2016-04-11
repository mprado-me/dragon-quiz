using UnityEngine;
using System.Collections;

public class GameFactory : MonoBehaviour2 {

    public GameObject gamePrefab;

    private static GameFactory _instance;

    public GameController CreateGame() {
        GameObject game = AddChild(gamePrefab);
        GameController gameController = game.GetComponent<GameController>();
        GameStorer gameStorer = GameStorer.Instance;
        gameStorer.GameController = gameController;
        gameController.Init();
        gameStorer.GameData = gameController.Data;
        return gameController;
    }

    public static GameFactory Instance
    {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<GameFactory>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
