using UnityEngine;
using System.Collections;

public class PipesSettings : MonoBehaviour {

    private static PipesSettings _instance;

    public float minVisibleYSize = 1f;
    public float yDist = 5f;
    public float xToDestroy = -12f;

    public static PipesSettings Instance
    {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<PipesSettings>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}