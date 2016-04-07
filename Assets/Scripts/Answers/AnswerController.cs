using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnswerController : MonoBehaviour2 {

    private SpriteRenderer _baloon;
    private Image _answerImage;
    private Text _answerText;
    private float _delta;

    void Start () {
        _baloon = GetComponentInChildren<SpriteRenderer>();
        _answerImage = GetComponentInChildren<Image>();
        _answerText = GetComponentInChildren<Text>();
        SetAlpha(0f);
        _delta = 0f;
    }

	void Update () {
	    if( _delta < AnswersSettings.Instance.appearTime) {
            _delta += Time.deltaTime;
            float t = _delta / AnswersSettings.Instance.appearTime;
            SetAlpha(Mathf.Lerp(0f, 1f, t));
        }
	}

    private void SetAlpha(float alpha) {
        _baloon.SetAlpha(alpha);
        if(_answerImage)
            _answerImage.canvasRenderer.SetAlpha(alpha);
        if(_answerText)
            _answerText.canvasRenderer.SetAlpha(alpha);
    }
}
