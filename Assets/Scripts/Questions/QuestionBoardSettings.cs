using UnityEngine;
using System.Collections;

public class QuestionBoardSettings : MonoBehaviour2 {

    public float contentDistance = 0.1f;

    private static QuestionBoardSettings _instance;

    public static QuestionBoardSettings Instance
    {
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<QuestionBoardSettings>();

            return _instance;
        }

        set
        {
            _instance = value;
        }
    }
}
