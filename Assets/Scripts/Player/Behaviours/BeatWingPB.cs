using UnityEngine;
using System.Collections;
using System;

public class BeatWingPB : PlayerBehaviour {

    private Sprite[] _sprites;
    private int _nSprites;
    private int _currentIdx;
    private bool _goRight;
    private float _delta;
    private SpriteRenderer _frontWingSR;
    private SpriteRenderer _backWingSR;


    public override void Start() {
        if( _sprites == null ) {
            _sprites = Resources.LoadAll<Sprite>("Images/Dragon/red_wings");
            _nSprites = _sprites.Length;
            _currentIdx = 0;
            _goRight = true;
            _delta = 0.0f;
        }
        foreach(SpriteRenderer sr in Controller.GetComponentsInChildren<SpriteRenderer>()) {
            if(sr.ContainTag("BackWing"))
                _backWingSR = sr;
            else if(sr.ContainTag("FrontWing"))
                _frontWingSR = sr;
        }
    }

    public override void Update() {
        _delta += Time.deltaTime;
        if(_delta >= PlayerSettings.Instance.wingCyclePeriod / (2 * (_nSprites - 1))) {
            _delta = 0.0f;
            if( _goRight) {
                if( _currentIdx == _nSprites-1) {
                    _goRight = false;
                    _currentIdx--;
                    _backWingSR.sprite = _sprites[_currentIdx];
                    _frontWingSR.sprite = _sprites[_currentIdx];
                } else {
                    _currentIdx++;
                    _backWingSR.sprite = _sprites[_currentIdx];
                    _frontWingSR.sprite = _sprites[_currentIdx];
                }
            } else {
                if(_currentIdx == 0) {
                    _goRight = true;
                    _currentIdx++;
                    _backWingSR.sprite = _sprites[_currentIdx];
                    _frontWingSR.sprite = _sprites[_currentIdx];
                }
                else {
                    _currentIdx--;
                    _backWingSR.sprite = _sprites[_currentIdx];
                    _frontWingSR.sprite = _sprites[_currentIdx];
                }
            }
        }
    }
}
