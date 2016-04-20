using UnityEngine;
using System.Collections;

public class ArrowSettings : MonoBehaviour2 {

    public float timeShowing = 0.3f;
    public float timeGoing = 0.5f;
    public float vel = 2f;
    public float spawnerPeriod = 0.8f;
    public float finalApha = 0.4f;
    [SerializeField]
    private Transform jumpStartTutorial;
    [SerializeField]
    private Transform choiceUpAnswer;
    [SerializeField]
    private Transform choiceDownAnswer;


    private static ArrowSettings _instance;

    public static ArrowSettings Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<ArrowSettings>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }

    public Vector3 JumpStartTutorialPos {
        get {
            return jumpStartTutorial.transform.position;
        }
    }

    public Vector3 ChoiceUpAnswer {
        get {
            return choiceUpAnswer.transform.position;
        }
    }

    public Vector3 ChoiceDownAnswer {
        get {
            return choiceDownAnswer.transform.position;
        }
    }
}
