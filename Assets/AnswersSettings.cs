using UnityEngine;
using System.Collections;

public class AnswersSettings : MonoBehaviour2 {

    public float maxSmallXSize = 200f;
    public float appearTime = 1.0f;

    private static AnswersSettings _instance;

    public static AnswersSettings Instance
    {
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<AnswersSettings>();

            return _instance;
        }

        set
        {
            _instance = value;
        }
    }
}
