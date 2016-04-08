using UnityEngine;
using System.Collections;

public class JumpStartTutorialGS : GameState {

    private bool _inAnFinished = false;
    QuestionBoardController _questionBoardController;

    protected override void Enter() {
        _questionBoardController = QuestionBoardStorer.Instance.QuestionBoardController;

        _questionBoardController.InitNewQuestionContent();
        _questionBoardController.AddImage("Images/Tutorial/spacebar");
        _questionBoardController.AddText("or");
        _questionBoardController.AddImage("Images/Tutorial/mouse_left_click");
        _questionBoardController.AddText("to jump and start");
        _questionBoardController.FinishNewQuestionContent();

        _questionBoardController.InitInAn();

        _questionBoardController.On(QuestionBoardEvent.ON_FINISH_IN_AN, delegate { _inAnFinished = true; });
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        if(_inAnFinished && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))) {
            _questionBoardController.InitOutAn();
            Controller.Invoke(GameEvent.EXIT_JUMP_START_TUTORIAL);
            return GameStatesStorer.Instance.Get<DivertingObstaclesGS>();
        }
        else
            return null;
    }

    protected override void Exit() {
        _questionBoardController.Remove(QuestionBoardEvent.ON_FINISH_IN_AN, delegate { _inAnFinished = true; });
    }
}
