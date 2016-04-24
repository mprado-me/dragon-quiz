using UnityEngine;
using System.Collections;

public class MarkersStorer {

    private DistanceMarkerController _distanceMarkerController;
    private CorrectAnswersMarkerController _correctAnswersMarkerController;

    private static MarkersStorer _instance;

    public static MarkersStorer Instance {
        get {
            if(_instance == null) {
                _instance = new MarkersStorer();
            }

            return _instance;
        }

        set {
            _instance = value;
        }
    }

    public DistanceMarkerController DistanceMarkerController {
        get {
            return _distanceMarkerController;
        }

        set {
            _distanceMarkerController = value;
        }
    }

    public CorrectAnswersMarkerController CorrectAnswersMarkerController {
        get {
            return _correctAnswersMarkerController;
        }

        set {
            _correctAnswersMarkerController = value;
        }
    }
}
