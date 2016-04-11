using UnityEngine;
using System.Collections;
using System;

public class DestroyOnPlayerEnterInHorizontalPipeB : MonoBehaviour2 {

    private GameController _gameController;

    void Start() {
        _gameController = GameStorer.Instance.GameController;
        _gameController.On(GameEvent.EXITING_HORIZONTAL_PIPE_START, MyDestroy);
    }

    private void MyDestroy() {
        Destroy(gameObject);
    }

    public void OnDestroy() {

    }

    void Update() {

    }
}
