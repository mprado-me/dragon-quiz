using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionBoardFactory : MonoBehaviour2 {

    public GameObject questionBoardPrefab;

    private static QuestionBoardFactory _instance;

    public void CreateQuestionBoard() {
        GameObject questionBoard = AddChild(questionBoardPrefab);
        //Debug.Log(questionBoard.transform.localScale);
        QuestionBoardStorer.Instance.QuestionBoardController = questionBoard.GetComponent<QuestionBoardController>();
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
