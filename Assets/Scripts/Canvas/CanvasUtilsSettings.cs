using UnityEngine;
using System.Collections;

public class CanvasUtilsSettings : MonoBehaviour2 {

    public float blinkPeriodAdditionalText = 0.75f;

    private static CanvasUtilsSettings _instance;

    public static CanvasUtilsSettings Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<CanvasUtilsSettings>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
