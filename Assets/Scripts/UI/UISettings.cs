using UnityEngine;
using System.Collections;

public class UISettings : MonoBehaviour2 {

    public float gameOverMenuShowTime = 0.8f;
    [SerializeField]
    private Transform _tryAgainButtonGameOverMenu;
    [SerializeField]
    private Transform _goMainMenuButtonGameOverMenu;

    private static UISettings _instance;

    public static UISettings Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<UISettings>();
            return _instance;
        }

        set {
            _instance = value;
        }
    }

    public Vector3 GoMainMenuButtonGameOverMenuPos {
        get {
            return _goMainMenuButtonGameOverMenu.transform.position;
        }
    }

    public Vector3 TryAgainButtonGameOverMenuPos {
        get {
            return _tryAgainButtonGameOverMenu.transform.position;
        }
    }
}
