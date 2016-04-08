using UnityEngine;
using System.Collections;

public abstract class Controller<S, D> : MonoBehaviour2 where S : Settings where D : Data {

    private D _data;
    private S _settings;

    public D Data {
        get {
            return _data;
        }

        set {
            _data = value;
        }
    }

    public S Settings {
        get {
            return _settings;
        }

        set {
            _settings = value;
        }
    }

    public abstract void Init();
    public abstract void ClearBehaviours();
}
