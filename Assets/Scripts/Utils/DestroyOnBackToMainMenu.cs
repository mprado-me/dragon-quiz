using UnityEngine;
using System.Collections;

public class DestroyOnBackToMainMenu : MonoBehaviour2 {

    GameController _gameController;

    void Start () {
        _gameController = GameStorer.Instance.GameController;
        _gameController.On(GameEvent.BACK_TO_MAIN_MENU, MyDestroy);
    }

    private void MyDestroy() {
        Destroy(gameObject);
    }

    public void OnDestroy() {
        _gameController.Remove(GameEvent.BACK_TO_MAIN_MENU, MyDestroy);
    }
}
