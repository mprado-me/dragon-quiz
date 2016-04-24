using UnityEngine;
using System.Collections;

public class MarkersFactory : MonoBehaviour2 {

    public GameObject distanceMarkerPrefab;
    public GameObject correctAnswersMarkerPrefab;

    private static MarkersFactory _instance;

    public void CreateDistanceMarker() {
        GameObject go = Instantiate(distanceMarkerPrefab);
        go.transform.SetParent(transform, false);
        DistanceMarkerController distanceMarkerController = go.GetComponent<DistanceMarkerController>();
        MarkersStorer.Instance.DistanceMarkerController = distanceMarkerController;
    }

    public void CreateCorrectAnswersMarker() {
        GameObject go = Instantiate(correctAnswersMarkerPrefab);
        go.transform.SetParent(transform, false);
        CorrectAnswersMarkerController CorrectAnswersMarkerController = go.GetComponent<CorrectAnswersMarkerController>();
        MarkersStorer.Instance.CorrectAnswersMarkerController = CorrectAnswersMarkerController;
    }


    public static MarkersFactory Instance {
        get {
            if(_instance == null) {
                _instance = GameObject.FindObjectOfType<MarkersFactory>();
            }

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
