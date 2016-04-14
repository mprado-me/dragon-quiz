using UnityEngine;
using System.Collections;
using System;

public class EnterHorizontalPipeTutorialGS : GameState {

    private float _velPlayerScenario;
    private QuestionBoardController _questionBoardController;
    private bool _finishInAn;
    private float _delta;
    private GameObject _additionalTextGO;

    protected override void Enter() {
        _velPlayerScenario = Controller.VelPlayerScenario;
        _finishInAn = false;
        _delta = 0f;

        Controller.VelPlayerScenario = 0f;

        _questionBoardController = QuestionBoardStorer.Instance.QuestionBoardController;
        _questionBoardController.InitNewQuestionContent();
        _questionBoardController.AddText("Enter in the correct pipe");
        _questionBoardController.FinishNewQuestionContent();
        _questionBoardController.InitInAn();
        _questionBoardController.On(QuestionBoardEvent.ON_FINISH_IN_AN, OnFinishInAn);
    }

    private void OnFinishInAn() {
        _finishInAn = true;
        Debug.Log("OnFinishInAn");
        _additionalTextGO = CanvasFactory.Instance.CreateAdditionalText("click or space to continue...");
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        if(_finishInAn)
            _delta += Time.deltaTime;

        if(_delta >= GameSettings.Instance.timeToEnableTutorialExit && ( Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))) {
            Controller.Invoke(GameEvent.GO_OUT_ENTER_PIPE_TUTORIAL);
            GameObject.Destroy(_additionalTextGO);
            return GameStatesStorer.Instance.Get<ChoicingAnswerGS>();
        }
        return null;
    }

    protected override void Exit() {
        Controller.VelPlayerScenario = _velPlayerScenario;

        _questionBoardController.InitOutAn();

        _questionBoardController.Remove(QuestionBoardEvent.ON_FINISH_IN_AN, OnFinishInAn);
    }
}