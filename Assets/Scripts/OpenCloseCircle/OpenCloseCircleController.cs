using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum OpenCloseCircleState {
    OPENED,
    OPENING,
    CLOSING,
    CLOSED
}

public class OpenCloseCircleController : MonoBehaviour2 {

    private OpenCloseCircleState _state;
    private float _radius;
    private List<Transform> _blackRects;
    private float _alpha;
    private float _delta;

    void Start() {
        _state = OpenCloseCircleState.OPENED;
        _blackRects = new List<Transform>();
        _radius = OpenCloseCircleSettings.Instance.openedRadius;
        _alpha = 2 * Mathf.PI / OpenCloseCircleSettings.Instance.nBlackRects;

        for(int i = 0; i < OpenCloseCircleSettings.Instance.nBlackRects; i++) {
            Transform t = OpenCloseCircleFactory.Instance.CreateBlackRect().transform;
            t.SetParent(transform, false);
            t.localPosition = Vector3.zero;
            t.localEulerAngles = Vector3.forward * _alpha * i * Mathf.Rad2Deg;
            _blackRects.Add(t);
        }

        UpdateBlackRects();
    }

    public void Open() {
        if(_state == OpenCloseCircleState.CLOSED) {
            _delta = 0f;
            _state = OpenCloseCircleState.OPENING;
        }
    }

    public void Close() {
        if(_state == OpenCloseCircleState.OPENED) {
            _delta = 0f;
            _state = OpenCloseCircleState.CLOSING;
        }
    }

    void Update() {
        _delta += Time.deltaTime;
        float t = _delta / OpenCloseCircleSettings.Instance.openCloseTime;

        switch(_state) {
            case OpenCloseCircleState.OPENING:
                UpdateOpening(t);
                break;
            case OpenCloseCircleState.CLOSING:
                UpdateClosing(t);
                break;
        }
    }

    private void UpdateOpening(float t) {
        UpdateAng();
        _radius = Mathf.Lerp(
                    OpenCloseCircleSettings.Instance.closedRadius,
                    OpenCloseCircleSettings.Instance.openedRadius,
                    t);
        UpdateBlackRects();
        if(t >= 1f)
            _state = OpenCloseCircleState.OPENED;
    }

    private void UpdateClosing(float t) {
        UpdateAng();
        _radius = Mathf.Lerp(
                    OpenCloseCircleSettings.Instance.openedRadius,
                    OpenCloseCircleSettings.Instance.closedRadius,
                    t);
        UpdateBlackRects();
        if(t >= 1f)
            _state = OpenCloseCircleState.CLOSED;
    }

    private void UpdateAng() {
        transform.localEulerAngles = Vector3.forward * (transform.localEulerAngles.z + Time.deltaTime * OpenCloseCircleSettings.Instance.angularVel);
    }

    private void UpdateBlackRects() {
        float ang = 0f;
        foreach(Transform t in _blackRects) {
            t.localPosition = (new Vector3(Mathf.Cos(ang), Mathf.Sin(ang))) * _radius;
            ang += _alpha;
        }
    }
}
