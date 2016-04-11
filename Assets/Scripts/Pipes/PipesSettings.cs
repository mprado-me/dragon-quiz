using UnityEngine;
using System.Collections;

public class PipesSettings : MonoBehaviour {

    private static PipesSettings _instance;

    public float minVisibleYSize = 1f;
    public float yDist = 5f;
    public float xToDestroy = -12f;
    [SerializeField]
    private Transform upHorizontalPipe;
    [SerializeField]
    private Transform downHorizontalPipe;

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

    public float HorizontalXStop {
        get {
            return upHorizontalPipe.position.x;
        }
    }

    public float HorizontalUpY {
        get {
            return upHorizontalPipe.position.y;
        }
    }

    public float HorizontalDownY {
        get {
            return downHorizontalPipe.position.y;
        }
    }

}