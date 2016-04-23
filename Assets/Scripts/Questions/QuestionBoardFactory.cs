using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionBoardFactory : MonoBehaviour2 {

    public GameObject questionBoardPrefab;

    private static QuestionBoardFactory _instance;

    public QuestionBoardController CreateQuestionBoard() {
        GameObject questionBoard = AddChild(questionBoardPrefab);
        questionBoard.GetComponentInChildren<Image>().SetAlpha(QuestionBoardSettings.Instance.alpha);
        //Debug.Log(questionBoard.transform.localScale);
        QuestionBoardController questionBoardController = questionBoard.GetComponent<QuestionBoardController>();
        QuestionBoardStorer.Instance.QuestionBoardController = questionBoardController;
        return questionBoardController;
    }

    public static QuestionBoardFactory Instance
    {
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<QuestionBoardFactory>();

            return _instance;
        }

        set
        {
            _instance = value;
        }
    }
}
