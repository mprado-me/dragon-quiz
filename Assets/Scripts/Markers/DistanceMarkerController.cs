using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class DistanceMarkerController : MonoBehaviour {

    private float _distance;
    private GameController _gameController;
    private Text _text;
    private Text _textShadown;

    void Start () {
        _distance = 0f;
        _gameController = GameStorer.Instance.GameController;
        foreach( Text t in GetComponentsInChildren<Text>()) {
            if(t.transform.ContainTag("Text"))
                _text = t;
            else if(t.transform.ContainTag("TShadown"))
                _textShadown = t;
        }
        Debug.Log(_text);
        Debug.Log(_textShadown);
    }
	
	void Update () {
        _distance += Time.deltaTime * _gameController.VelPlayerScenario * MarkersSettings.Instance.distanceFactor;
        _text.text = Mathf.RoundToInt(_distance) + "m";
        _textShadown.text = _text.text;
    }

    public void SetInactive() {
        gameObject.SetActive(false);
    }

    public void SetActive() {
        gameObject.SetActive(true);
    }

    public void ClearDistance() {
        _distance = 0f;
    }

    public int GetDistance() {
        return Mathf.RoundToInt(_distance);
    }
}
