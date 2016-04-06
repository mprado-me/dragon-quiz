using UnityEngine;
using System.Collections;
using System;

public class QuestionVisibleGS : GameState {

    protected override void Enter() {
        QuestionBoardController questionBoardController = QuestionBoardStorer.Instance.QuestionBoardController;

        questionBoardController.SetQuestion(QuestionGenerator.Instance.GetNew());
        questionBoardController.InitInAn();
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return null;
    }

    protected override void Exit() {
    }
}
