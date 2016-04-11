using UnityEngine;
using System.Collections;

public enum HorizontalPipe {
    UP,
    DOWN
}

public class GameData : Data {

    private Question _question;
    private HorizontalPipe _correctAnswer;
    private HorizontalPipe _horizontalPipeEntered;
    private HorizontalPipeController _upHorizontalPipeController;
    private HorizontalPipeController _downHorizontalPipeController;

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

    public HorizontalPipeController UpHorizontalPipeController {
        get {
            return _upHorizontalPipeController;
        }

        set {
            _upHorizontalPipeController = value;
        }
    }

    public HorizontalPipeController DownHorizontalPipeController {
        get {
            return _downHorizontalPipeController;
        }

        set {
            _downHorizontalPipeController = value;
        }
    }

    public HorizontalPipe HorizontalPipeEntered {
        get {
            return _horizontalPipeEntered;
        }
        set {
            _horizontalPipeEntered = value;
        }
    }
}
