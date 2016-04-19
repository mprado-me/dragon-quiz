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
    private bool _jumpStartTutorialAlreadyShowed;
    private bool _enterPipeTutorialAlreadyShowed;
    private int _nCorrectAnswers;
    private int _distance;
    private int _nCorrectAnswersRecord;
    private int _distanceRecord;

    public GameData() : base() {
        JumpStartTutorialAlreadyShowed = false;
        EnterPipeTutorialAlreadyShowed = false;
    }

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

    public bool JumpStartTutorialAlreadyShowed {
        get {
            return _jumpStartTutorialAlreadyShowed;
        }

        set {
            _jumpStartTutorialAlreadyShowed = value;
        }
    }

    public bool EnterPipeTutorialAlreadyShowed {
        get {
            return _enterPipeTutorialAlreadyShowed;
        }

        set {
            _enterPipeTutorialAlreadyShowed = value;
        }
    }

    public int NCorrectAnswers {
        get {
            return _nCorrectAnswers;
        }

        set {
            _nCorrectAnswers = value;
        }
    }

    public int Distance {
        get {
            return _distance;
        }

        set {
            _distance = value;
        }
    }

    public int NCorrectAnswersRecord {
        get {
            return _nCorrectAnswersRecord;
        }

        set {
            _nCorrectAnswersRecord = value;
        }
    }

    public int DistanceRecord {
        get {
            return _distanceRecord;
        }

        set {
            _distanceRecord = value;
        }
    }
}
