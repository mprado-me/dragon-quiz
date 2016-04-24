using UnityEngine;
using System.Collections;

public class QuestionSettings : MonoBehaviour2 {

    public float mathQuestionChance = 0.35f;

    private static QuestionSettings _instance;

    public static QuestionSettings Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<QuestionSettings>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
