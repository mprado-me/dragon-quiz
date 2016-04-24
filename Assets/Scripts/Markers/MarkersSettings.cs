using UnityEngine;
using System.Collections;

public class MarkersSettings : MonoBehaviour2 {

    public float distanceFactor = 0.2f;

    private static MarkersSettings _instance;

    public static MarkersSettings Instance {
        get {
            if(_instance == null) {
                _instance = GameObject.FindObjectOfType<MarkersSettings>();
            }

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
