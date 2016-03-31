using UnityEngine;
using System.Collections;

public class QuestionBoardController : MonoBehaviour2 {

    private Animator _animator;

    void Start () {
        _animator = GetComponent<Animator>();
    }
	
	void Update () {
	    
	}

    public void InitInAn() {
        _animator.SetTrigger("initInQuestionBoardAn");
    }

    public void InitOutAn() {
        _animator.SetTrigger("initOutQuestionBoardAn");
    }
}
