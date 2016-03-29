using UnityEngine;
using System.Collections;
using System;

public class BeatWingPB : PlayerBehaviour {

    private Sprite[] _sprites;
    private int _nSprites;
    private int _currentIdx;
    private bool _goRight;
    private float _delta;


    public override void Start() {
        if( _sprites == null ) {
            _sprites = Resources.LoadAll<Sprite>("Images/Dragon/red_wings");
            _nSprites = _sprites.Length;
            _currentIdx = 0;
            _goRight = true;
            _delta = 0.0f;
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
                    Data.BackWingSR.sprite = _sprites[_currentIdx];
                    Data.FrontWingSR.sprite = _sprites[_currentIdx];
                } else {
                    _currentIdx++;
                    Data.BackWingSR.sprite = _sprites[_currentIdx];
                    Data.FrontWingSR.sprite = _sprites[_currentIdx];
                }
            } else {
                if(_currentIdx == 0) {
                    _goRight = true;
                    _currentIdx++;
                    Data.BackWingSR.sprite = _sprites[_currentIdx];
                    Data.FrontWingSR.sprite = _sprites[_currentIdx];
                }
                else {
                    _currentIdx--;
                    Data.BackWingSR.sprite = _sprites[_currentIdx];
                    Data.FrontWingSR.sprite = _sprites[_currentIdx];
                }
            }
        }
    }
}
