using UnityEngine;
using System.Collections;

public class JumpStartTutorialGS : GameState {

    private bool inAnFinished = false;

    protected override void Enter() {
        QuestionBoardStorer.Instance.QuestionBoardController.InitNewQuestionContent();
        QuestionBoardStorer.Instance.QuestionBoardController.AddImage("Images/Tutorial/spacebar");
        QuestionBoardStorer.Instance.QuestionBoardController.AddText("or");
        QuestionBoardStorer.Instance.QuestionBoardController.AddImage("Images/Tutorial/mouse_left_click");
        QuestionBoardStorer.Instance.QuestionBoardController.AddText("to jump and start");
        QuestionBoardStorer.Instance.QuestionBoardController.FinishNewQuestionContent();
        QuestionBoardStorer.Instance.QuestionBoardController.InitInAn();
        QuestionBoardStorer.Instance.QuestionBoardController.On(QuestionBoardEvent.ON_FINISH_IN_AN, delegate { inAnFinished = true; });
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        if(inAnFinished && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))) {
            QuestionBoardStorer.Instance.QuestionBoardController.InitOutAn();
            Controller.Invoke(GameEvent.ON_EXIT_JUMP_START_TUTORIAL);
            return GameStatesStorer.Instance.Get<DivertingObstaclesGS>();
        }
        else
            return null;
    }

    protected override void Exit() {
    }
}
