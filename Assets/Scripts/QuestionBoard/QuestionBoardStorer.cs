using UnityEngine;
using System.Collections;

public class QuestionBoardStorer {

    private QuestionBoardController _questionBoardController;

    private static QuestionBoardStorer _instance;

    public QuestionBoardController QuestionBoardController
    {
        get
        {
            return _questionBoardController;
        }

        set
        {
            _questionBoardController = value;
        }
    }

    public static QuestionBoardStorer Instance
    {
        get
        {
            if(_instance == null) {
                _instance = new QuestionBoardStorer();
            }
            return _instance;
        }
    }
}
