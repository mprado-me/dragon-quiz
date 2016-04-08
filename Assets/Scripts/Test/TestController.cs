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
        //TestPlayerDieOnCeilFloorCollision();
        //TestVerticalPipeCreation();
        //TestQuestionBoard1();
        //TestQuestionBoard2();
        //TestQuestionTextImageCreation();
        //TestSetQuestionFromJSONFile1();
        //TestCreateAnswer();
        //TestGreenHorizontalPipe();
        TestOpenCloseCircle();
    }

    private void TestOpenCloseCircle() {
        StartCoroutine(TestOpenCloseCircleCoroutine());
    }
    private IEnumerator TestOpenCloseCircleCoroutine() {
        OpenCloseCircleController c = OpenCloseCircleFactory.Instance.CreateOpenCloseCircle();
        yield return new WaitForSeconds(0.25f);
        while(true) {
            yield return new WaitForSeconds(1.1f * OpenCloseCircleSettings.Instance.openCloseTime);
            c.Close();
            yield return new WaitForSeconds(1.1f * OpenCloseCircleSettings.Instance.openCloseTime);
            c.Open();
        }
    }

    private void TestGreenHorizontalPipe() {
        StartCoroutine(TestGreenHorizontalPipeCreatePlayer());
        
    }
    private IEnumerator TestGreenHorizontalPipeCreatePlayer() {
        yield return new WaitForSeconds(0.25f);
        ScenariosManager.Instance._DANGER_UnsafeSetVel(-GameSettings.Instance.vel);
        PipesFactory.Instance.CreateUpHorizontalPipe();
        PipesFactory.Instance.CreateDownHorizontalPipe();
        yield return new WaitForSeconds(0.25f);
        GameController gc = FindObjectOfType<MockGameController>();
        gc.VelPlayerScenario = GameSettings.Instance.vel;
        GameStorer.Instance.GameController = gc;
        PlayerFactory.Instance.CreatePlayer();
        PlayerStorer.Instance.PlayerController.X = -Camera.main.orthographicSize*1.2f;
        PlayerStorer.Instance.PlayerController.YVel = PlayerSettings.Instance.jumpVel;
        PlayerSettings.Instance.GetInitialState = new PlayerSettings.GetInitialStateDelegate(GetInitialState2);
    }
    private PlayerState GetInitialState2() {
        return PlayerStatesStorer.Instance.Get<ChoicingAnswerPS>();
    }

    private void TestCreateAnswer() {
        AnswersFactory.Instance.CreateUp(AnswerType.IMAGE, "Soccer Ball");
        AnswersFactory.Instance.CreateDown(AnswerType.TEXT, "a23aa");
    }

    private void TestSetQuestionFromJSONFile1() {
        QuestionBoardFactory.Instance.CreateQuestionBoard();
        StartCoroutine(TestSetQuestionFromJSONFile2());
    }
    private IEnumerator TestSetQuestionFromJSONFile2() {
        yield return new WaitForSeconds(0.5f);
        QuestionBoardStorer.Instance.QuestionBoardController.SetQuestion(QuestionGenerator.Instance.GetNew());
        QuestionBoardStorer.Instance.QuestionBoardController.InitInAn();
        yield return new WaitForSeconds(2f);
        QuestionBoardStorer.Instance.QuestionBoardController.InitOutAn();
        yield return new WaitForSeconds(2f);
        QuestionBoardStorer.Instance.QuestionBoardController.InitNewQuestionContent();
    }

    private void TestQuestionBoard2() {
        QuestionBoardFactory.Instance.CreateQuestionBoard();
        StartCoroutine(TestQuestionBoardUpdate2());
    }
    private IEnumerator TestQuestionBoardUpdate2() {
        yield return new WaitForSeconds(0.5f);
        QuestionBoardStorer.Instance.QuestionBoardController.InitNewQuestionContent();
        QuestionBoardStorer.Instance.QuestionBoardController.AddImage("Images/Tutorial/spacebar");
        QuestionBoardStorer.Instance.QuestionBoardController.AddText("or");
        QuestionBoardStorer.Instance.QuestionBoardController.AddImage("Images/Tutorial/mouse_left_click");
        QuestionBoardStorer.Instance.QuestionBoardController.AddText("to jump and start");
        QuestionBoardStorer.Instance.QuestionBoardController.FinishNewQuestionContent();
        QuestionBoardStorer.Instance.QuestionBoardController.InitInAn();
        yield return new WaitForSeconds(2f);
        QuestionBoardStorer.Instance.QuestionBoardController.InitOutAn();
        yield return new WaitForSeconds(2f);
        QuestionBoardStorer.Instance.QuestionBoardController.InitNewQuestionContent();
    }

    private void TestQuestionTextImageCreation() {
        GameObject go = CanvasFactory.Instance.CreateText("oi amiguinho como vai vc eu vou bem");
        go.transform.parent = QuestionBoardFactory.Instance.transform;
        go = CanvasFactory.Instance.CreateText("oi");
        go.transform.parent = QuestionBoardFactory.Instance.transform;
        go = CanvasFactory.Instance.CreateText("oi amiguinho");
        go.transform.parent = QuestionBoardFactory.Instance.transform;
        go = CanvasFactory.Instance.CreateImage("Images/Tutorial/mouse_left_click");
        go.transform.parent = QuestionBoardFactory.Instance.transform;
        go = CanvasFactory.Instance.CreateImage("Images/Tutorial/spacebar");
        go.transform.parent = QuestionBoardFactory.Instance.transform;
    }

    private void TestQuestionBoard1() {
        QuestionBoardFactory.Instance.CreateQuestionBoard();
        StartCoroutine(TestQuestionBoardUpdate1());
    }
    private IEnumerator TestQuestionBoardUpdate1() {
        yield return new WaitForSeconds(0.5f);
        QuestionBoardStorer.Instance.QuestionBoardController.InitInAn();
        yield return new WaitForSeconds(2f);
        QuestionBoardStorer.Instance.QuestionBoardController.InitOutAn();
    }

    private void TestVerticalPipeCreation() {
        ScenariosManager.Instance._DANGER_UnsafeSetVel(-5f);
        PipesFactory.Instance.CreateFixedVerticalPipe();
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
        return PlayerStatesStorer.Instance.Get<DivertingObstaclesPS>();
    }

    private void TestPlayerDieOnFloorCollision() {
        ScenariosManager.Instance.Current = ScenarioType.GROUND;
        PlayerFactory.Instance.CreatePlayer();
        pc = PlayerStorer.Instance.PlayerController;
        this.Invoke("TestPlayerDieOnFloorCollision2", 0.1f);
    }
    private void TestPlayerDieOnFloorCollision2() {
        pc.State = new DivertingObstaclesPS();
        pc.XVel = 0.0f;
        //Mock.Instance.VelPlayerScenario = 2f;
    }

    private void TestPlayerRelScenarioMove() {
        ScenariosManager.Instance.Current = ScenarioType.GROUND;
        PlayerFactory.Instance.CreatePlayer();
        pc = PlayerStorer.Instance.PlayerController;
        this.Invoke("TestPlayerRelScenarioMove2", 0.1f);
    }
    private void TestPlayerRelScenarioMove2() {
        pc.State = new DivertingObstaclesPS();
        pc.XVel = 0.5f;
        //Mock.Instance.VelPlayerScenario = 1f;
    }

    private void TestPlayerYMove() {
        ScenariosManager.Instance.Current = ScenarioType.GROUND;
        PlayerFactory.Instance.CreatePlayer();
        pc = PlayerStorer.Instance.PlayerController;
        this.Invoke("TestPlayerYMove2", 0.1f);
    }
    private void TestPlayerYMove2() {
        pc.State = new DivertingObstaclesPS();
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
