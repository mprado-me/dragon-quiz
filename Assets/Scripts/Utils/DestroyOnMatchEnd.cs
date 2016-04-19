using UnityEngine;
using System.Collections;

public class DestroyOnMatchEnd : MonoBehaviour2 {

    GameController _gameController;

    void Start () {
        _gameController = GameStorer.Instance.GameController;
        _gameController.On(GameEvent.MATCH_END, MyDestroy);
    }

    private void MyDestroy() {
        Destroy(gameObject);
    }

    public void OnDestroy() {
        _gameController.Remove(GameEvent.MATCH_END, MyDestroy);
    }
}
