using UnityEngine;
using System.Collections;
using System;

public class MainMenuToLaunchingVerticalPipesGS : GameState {

    private GameState newState;

    public MainMenuToLaunchingVerticalPipesGS() {
    }

    protected override void Enter() {
        newState = null;
        MainMenuController mainMenuController = UIStorer.Instance.MainMenuController;
        mainMenuController.On(MainMenuEvent.OUT_ANIMATION_END, delegate { newState = GameStatesStorer.Instance.Get<LaunchingVerticalPipesGS>(); });
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return newState;
    }

    protected override void Exit() {
    }

    
}