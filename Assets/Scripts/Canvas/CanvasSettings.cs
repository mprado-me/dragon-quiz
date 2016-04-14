using UnityEngine;
using System.Collections;

public class CanvasSettings : MonoBehaviour2 {

    public float blinkPeriodAdditionalText = 0.75f;

    private static CanvasSettings _instance;

    public static CanvasSettings Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<CanvasSettings>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
