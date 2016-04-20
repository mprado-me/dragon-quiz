using UnityEngine;
using System.Collections;

public class ArrowFactory : MonoBehaviour {

    public GameObject arrowPrefab;
    public GameObject arrowSpawnerPrefab;

    private static ArrowFactory _instance;

    public GameObject CreateArrowSpawner(Vector3 pos, float ang) {
        GameObject go = Instantiate(arrowSpawnerPrefab);
        go.transform.SetParent(transform, false);
        go.transform.position = pos;
        go.transform.localEulerAngles = Vector3.forward * ang;
        return go;
    }

    // It's public beacause of the test
    public GameObject CreateArrow(Vector3 pos, float ang) {
        GameObject go = Instantiate(arrowPrefab);
        go.transform.SetParent(transform, false);
        go.transform.position = pos;
        go.transform.localEulerAngles = Vector3.forward * ang;
        return go;
    }

    public static ArrowFactory Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<ArrowFactory>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
