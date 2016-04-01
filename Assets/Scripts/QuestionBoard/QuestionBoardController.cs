﻿using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class QuestionBoardController : MonoBehaviour2 {

    private Animator _animator;
    private QuestionContentManager _contentManager;
    private QuestionBoardEventsManager _questionBoardEventsManager;

    void Start () {
        _animator = GetComponent<Animator>();
        _contentManager = new QuestionContentManager(this);
        _questionBoardEventsManager = new QuestionBoardEventsManager();
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

    public void On(QuestionBoardEvent questionBoardEvent, UnityAction call) {
        _questionBoardEventsManager.On(questionBoardEvent, call);
    }

    public void Invoke(QuestionBoardEvent questionBoardEvent) {
        _questionBoardEventsManager.Invoke(questionBoardEvent);
    }
}
