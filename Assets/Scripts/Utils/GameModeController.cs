﻿using UnityEngine;
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
        GameFactory.Instance.CreateGame();
    }

    private void CreateTest() {
        GameObject test = new GameObject("Test");
        test.AddComponent<TestController>();
    }
}
