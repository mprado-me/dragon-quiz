using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CorrectAnswersMarkerController : MonoBehaviour2 {

    private int _nCorrectAnswers;
    private GameController _gameController;
    private Text _text;
    private Text _textShadown;

    void Start () {
        _nCorrectAnswers = 0;
        _gameController = GameStorer.Instance.GameController;
        foreach(Text t in GetComponentsInChildren<Text>()) {
            if(t.transform.ContainTag("Text"))
                _text = t;
            else if(t.transform.ContainTag("TShadown"))
                _textShadown = t;
        }
        Debug.Log(_text);
        Debug.Log(_textShadown);
        _text.text = "" + _nCorrectAnswers;
        _textShadown.text = _text.text;
    }
	
	void Update () {
	
	}

    public void SetInactive() {
        gameObject.SetActive(false);
    }

    public void SetActive() {
        gameObject.SetActive(true);
    }

    public void ClearNCorrectAnswers() {
        _nCorrectAnswers = 0;
        _text.text = "" + _nCorrectAnswers;
        _textShadown.text = _text.text;
    }

    public void AnswerHit() {
        _nCorrectAnswers++;
        _text.text = "" + _nCorrectAnswers;
        _textShadown.text = _text.text;
    }

    public int GetNCorrectAnswers() {
        return _nCorrectAnswers;
    }
}
