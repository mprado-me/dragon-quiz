using UnityEngine;
using System.Collections;

public class OpenCloseCircleSettings : MonoBehaviour2 {

    public float openedRadius;
    public float closedRadius;
    public float nBlackRects;
    public float openCloseTime;
    public float angularVel;

    private static OpenCloseCircleSettings _instance;

    public static OpenCloseCircleSettings Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<OpenCloseCircleSettings>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
