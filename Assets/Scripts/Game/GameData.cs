using UnityEngine;
using System.Collections;

public enum HorizontalPipe {
    UP,
    DOWN
}

public class GameData : Data {

    private Question _question;
    private HorizontalPipe _correctAnswer;

    public Question Question {
        get {
            return _question;
        }

        set {
            _question = value;
        }
    }

    public HorizontalPipe CorrectAnswer {
        get {
            return _correctAnswer;
        }

        set {
            _correctAnswer = value;
        }
    }
}
