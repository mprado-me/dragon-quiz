using UnityEngine;
using System.Collections;

public class OpenCloseCircleFactory : MonoBehaviour2 {

    public GameObject openCloseCirclePrefab;
    public GameObject blackRectPrefab;

    private static OpenCloseCircleFactory _instance;

    public OpenCloseCircleController CreateOpenCloseCircle() {
        GameObject go = Instantiate(openCloseCirclePrefab);
        go.transform.SetParent(transform, false);
        go.transform.localPosition = Vector3.zero;
        OpenCloseCircleController controller = go.GetComponent<OpenCloseCircleController>();
        OpenCloseCircleStorer.Instance.OpenCloseCircleController = controller;
        return controller;
    }

    public GameObject CreateBlackRect() {
        return Instantiate(blackRectPrefab);
    }

    public static OpenCloseCircleFactory Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<OpenCloseCircleFactory>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
