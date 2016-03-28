using UnityEngine;
using System.Collections;
using System;

public class TestController : MonoBehaviour2 {

    private PlayerController pc;

    private void Start() {
        //MainMenuPrefab();
        //TestSkyScenario();
        //TestGroundScenario();
        //TestCaveScenario();
        //TestPlayerYMove();
        //TestPlayerRelScenarioMove();
        //TestPlayerDieOnFloorCollision();
        TestPlayerDieOnCeilFloorCollision();
    }

    private void MainMenuPrefab() {
        UIFactory.Instance.CreateMainMenu();
        MainMenuController mainMenuController = UIStorer.Instance.MainMenuController;
        mainMenuController.InitInAnimation();
        mainMenuController.On(MainMenuEvent.IN_ANIMATION_END, delegate { Debug.Log("MainMenu in animation end"); });
        mainMenuController.On(MainMenuEvent.PLAY_BUTTON_CLICK, delegate { Debug.Log("PlayButtonClicked"); });
    }

    private void TestPlayerDieOnCeilFloorCollision() {
        ScenariosManager.Instance.Current = ScenarioType.CAVE;
        PlayerFactory.Instance.CreatePlayer();
        PlayerSettings.Instance.GetInitialState = new PlayerSettings.GetInitialStateDelegate(GetInitialState);
        pc = PlayerStorer.Instance.PlayerController;
    }
    private PlayerState GetInitialState() {
        return PlayerStatesStorer.Instance.Get<DivertingVerticalPipesPS>();
    }

    private void TestPlayerDieOnFloorCollision() {
        ScenariosManager.Instance.Current = ScenarioType.GROUND;
        PlayerFactory.Instance.CreatePlayer();
        pc = PlayerStorer.Instance.PlayerController;
        this.Invoke("TestPlayerDieOnFloorCollision2", 0.1f);
    }
    private void TestPlayerDieOnFloorCollision2() {
        pc.State = new DivertingVerticalPipesPS();
        pc.NormalizedVel = 0.0f;
        Mock.Instance.VelPlayerScenario = 2f;
    }

    private void TestPlayerRelScenarioMove() {
        ScenariosManager.Instance.Current = ScenarioType.GROUND;
        PlayerFactory.Instance.CreatePlayer();
        pc = PlayerStorer.Instance.PlayerController;
        this.Invoke("TestPlayerRelScenarioMove2", 0.1f);
    }
    private void TestPlayerRelScenarioMove2() {
        pc.State = new DivertingVerticalPipesPS();
        pc.NormalizedVel = 0.5f;
        Mock.Instance.VelPlayerScenario = 1f;
    }

    private void TestPlayerYMove() {
        ScenariosManager.Instance.Current = ScenarioType.GROUND;
        PlayerFactory.Instance.CreatePlayer();
        pc = PlayerStorer.Instance.PlayerController;
        this.Invoke("TestPlayerYMove2", 0.1f);
    }
    private void TestPlayerYMove2() {
        pc.State = new DivertingVerticalPipesPS();
    }

    private void TestSkyScenario() {
        ScenariosManager sm = new ScenariosManager();
        sm.Current = ScenarioType.SKY;
    }

    private void TestGroundScenario() {
        ScenariosManager sm = new ScenariosManager();
        sm.Current = ScenarioType.GROUND;
    }

    private void TestCaveScenario() {
        ScenariosManager sm = new ScenariosManager();
        sm.Current = ScenarioType.CAVE;
    }
}
