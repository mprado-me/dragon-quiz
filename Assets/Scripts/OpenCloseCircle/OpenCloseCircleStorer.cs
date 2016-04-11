using UnityEngine;
using System.Collections;

public class OpenCloseCircleStorer {

    private OpenCloseCircleController _openCloseCircleController;

    private static OpenCloseCircleStorer _instance;

    private OpenCloseCircleStorer() {

    }

    public static OpenCloseCircleStorer Instance {
        get {
            if(_instance == null)
                _instance = new OpenCloseCircleStorer();

            return _instance;
        }

        set {
            _instance = value;
        }
    }

    public OpenCloseCircleController OpenCloseCircleController {
        get {
            return _openCloseCircleController;
        }

        set {
            _openCloseCircleController = value;
        }
    }
}
