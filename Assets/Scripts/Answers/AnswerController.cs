using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public enum AnswerState {
    SHOWING,
    WAITING_HORIZONTAL_PIPE,
    SHIFTING,
    WAITING_PLAYER_COME,
    UNSHOWING
}

public class AnswerController : MonoBehaviour2 {

    private AnswerState _currentState;

    private SpriteRenderer _baloon;
    private Image _answerImage;
    private Text _answerText;
    private float _delta;

    void Start() {
        _currentState = AnswerState.SHOWING;
        _baloon = GetComponentInChildren<SpriteRenderer>();
        _answerImage = GetComponentInChildren<Image>();
        _answerText = GetComponentInChildren<Text>();
        SetAlpha(0f);
        _delta = 0f;
    }

    void Update() {
        switch(_currentState) {
            case AnswerState.SHOWING:
                ShowingUpdate();
                break;
            case AnswerState.WAITING_HORIZONTAL_PIPE:
                break;
            case AnswerState.SHIFTING:
                ShiftingUpdate();
                break;
            case AnswerState.WAITING_PLAYER_COME:
                break;
            case AnswerState.UNSHOWING:
                break;
            default:
                break;
        }
    }

    private void ShowingUpdate() {
        if(_delta < AnswersSettings.Instance.appearTime) {
            _delta += Time.deltaTime;
            float t = _delta / AnswersSettings.Instance.appearTime;
            SetAlpha(Mathf.Lerp(0f, 1f, t));
            if(t >= 1f)
                _currentState = AnswerState.WAITING_HORIZONTAL_PIPE;
        } 
    }

    private void ShiftingUpdate() {
        transform.position = new Vector3(transform.position.x + Time.deltaTime * ScenariosManager.Instance.Vel, transform.position.y);
    }

    private void SetAlpha(float alpha) {
        _baloon.SetAlpha(alpha);
        if(_answerImage)
            _answerImage.canvasRenderer.SetAlpha(alpha);
        if(_answerText)
            _answerText.canvasRenderer.SetAlpha(alpha);
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if( other.ContainTag("HorizontalPipe")) {
            _currentState = AnswerState.SHIFTING;
        }
    }
}
