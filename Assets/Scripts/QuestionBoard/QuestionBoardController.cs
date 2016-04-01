using UnityEngine;
using System.Collections;

public class QuestionBoardController : MonoBehaviour2 {

    private Animator _animator;
    private QuestionContentManager _contentManager;

    void Start () {
        _animator = GetComponent<Animator>();
        _contentManager = new QuestionContentManager(this);
    }
	
	void Update () {

	}

    private bool temp;
    public void InitInAn() {
        _animator.SetTrigger("initInQuestionBoardAn");
    }

    public void InitOutAn() {
        _animator.SetTrigger("initOutQuestionBoardAn");
    }

    public void InitNewQuestionContent() {
        _contentManager.InitNewQuestionContent();
    }

    public void AddText(string text) {
        _contentManager.AddText(text);
    }

    public void AddImage(string adress) {
        _contentManager.AddImage(adress);
    }

    public void FinishNewQuestionContent() {
        _contentManager.FinishNewQuestionContent();
    }
}
