using UnityEngine;
using System.Collections;

public class GameFactory : MonoBehaviour2 {

    public GameObject gamePrefab;

    private static GameFactory _instance;

    public void CreateGame() {
        GameObject game = AddChild(gamePrefab);
        GameController gameController = game.GetComponent<GameController>();
        GameStorer.Instance.GameController = gameController;
        gameController.Init();
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
