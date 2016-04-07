using UnityEngine;

public class AnswersVisibleGS : GameState {

    protected override void Enter() {
        if( Random.Range(0, 2) == 0) {
            AnswersFactory.Instance.CreateUp(Data.Question.correctAnswerType, Data.Question.correctAnswerContent);
            AnswersFactory.Instance.CreateDown(Data.Question.incorrectAnswerType, Data.Question.incorrectAnswerContent);
            Data.CorrectAnswer = HorizontalPipe.UP;
        } else {
            AnswersFactory.Instance.CreateUp(Data.Question.incorrectAnswerType, Data.Question.incorrectAnswerContent);
            AnswersFactory.Instance.CreateDown(Data.Question.correctAnswerType, Data.Question.correctAnswerContent);
            Data.CorrectAnswer = HorizontalPipe.DOWN;
        }
       
    }

    protected override State<GameController, GameSettings, GameData> Update() {
        return null;
    }

    protected override void Exit() {
    }
}
