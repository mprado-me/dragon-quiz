using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

public enum GameOverMenuState {
    SHOWING,
    IDLE
}

public class GameOverMenuController : MonoBehaviour2 {

    private GameOverMenuEventsManager _eventsManager;
    private float _delta;
    private AlphaManager _alphaManager;

    private GameOverMenuState _state;
    public GameObject canvasTest;

    public void Init() {
        _eventsManager = new GameOverMenuEventsManager();
        _alphaManager = new AlphaManager(gameObject);
    }

    void Start () {
        _delta = 0f;
        _state = GameOverMenuState.SHOWING;
        SetAlpha(0f);
        Debug.Log(MarkersStorer.Instance.DistanceMarkerController.GetDistance());
        Debug.Log(MarkersStorer.Instance.CorrectAnswersMarkerController.GetNCorrectAnswers());
    }

    void Update () {
        switch(_state) {
            case GameOverMenuState.SHOWING:
                _delta += Time.deltaTime;
                float t = _delta / UISettings.Instance.gameOverMenuShowTime;
                SetAlpha(Mathf.Lerp(0f, 1f, t));
                break;
            case GameOverMenuState.IDLE:
                break;
        }
	}

    public void On(GameOverMenuEvent gameOverMenuEvent, UnityAction call) {
        _eventsManager.On(gameOverMenuEvent, call);
    }

    public void Remove(GameOverMenuEvent gameOverMenuEvent, UnityAction call) {
        _eventsManager.Remove(gameOverMenuEvent, call);
    }

    public void Invoke(GameOverMenuEvent gameOverMenuEvent) {
        _eventsManager.Invoke(gameOverMenuEvent);
    }

    public void Destroy() {
        Destroy(gameObject);
    }

    public void SetAlpha(float alpha) {
        _alphaManager.SetAlpha(alpha);
    }
}
