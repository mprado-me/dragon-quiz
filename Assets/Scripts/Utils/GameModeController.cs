using UnityEngine;
using System.Collections;
using System;

public enum Runnable {
    TEST,
    GAME
}

public class GameModeController : MonoBehaviour2 {

    public Runnable run;

    public void Awake() {
        if(run == Runnable.GAME) {
            CreateGame();
        }
        else {
            CreateTest();
        }
    }

    private void CreateGame() {
        GameObject game = new GameObject("Game");
        game.AddComponent<GameController>();
    }

    private void CreateTest() {
        GameObject test = new GameObject("Test");
        test.AddComponent<TestController>();
    }
}
