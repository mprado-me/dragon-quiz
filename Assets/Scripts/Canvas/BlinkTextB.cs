using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlinkTextB : MonoBehaviour2 {

    private Text _textComponent;
    private bool _increasingAlpha;
    private float _delta;

	void Start () {
        _textComponent = GetComponent<Text>();
        _increasingAlpha = true;
        _delta = 0f;
        _textComponent.color = new Color(
            _textComponent.color.r,
            _textComponent.color.g,
            _textComponent.color.b,
            _textComponent.color.a);
    }
	
	void Update () {
        _delta += Time.deltaTime;
        if( _increasingAlpha) {
            float t = _delta / CanvasUtilsSettings.Instance.blinkPeriodAdditionalText;
            _textComponent.color = new Color(
            _textComponent.color.r,
            _textComponent.color.g,
            _textComponent.color.b,
            Mathf.Lerp(0f, 1f, t));
            if( t >= 1f) {
                _delta = 0f;
                _increasingAlpha = false;
            }
        } else { // _decreasingAlpha
            float t = _delta / CanvasUtilsSettings.Instance.blinkPeriodAdditionalText;
            _textComponent.color = new Color(
            _textComponent.color.r,
            _textComponent.color.g,
            _textComponent.color.b,
            Mathf.Lerp(1f, 0f, t));
            if(t >= 1f) {
                _delta = 0f;
                _increasingAlpha = true;
            }
        }
	}
}
