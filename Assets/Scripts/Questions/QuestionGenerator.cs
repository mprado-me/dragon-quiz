using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using System;

public class QuestionGenerator : MonoBehaviour2 {

    private Queue<Question> _queue;
    private MathQuestionGenerator _mathQuestionGenerator;

    private static QuestionGenerator _instance;


    public void Start() {
        _queue = new Queue<Question>();
        _mathQuestionGenerator = new MathQuestionGenerator();
        AppendAll();
    }

    public Question GetNew() {
        if( UnityEngine.Random.Range(0f, 1f) < QuestionSettings.Instance.mathQuestionChance) {
            return _mathQuestionGenerator.GetNew();
        }
        else {
            return _queue.Dequeue();
        }
    }

    private void AppendAll() {
        TextAsset ta = Resources.Load<TextAsset>("questions");
        JSONArray questions = JSON.Parse(ta.text).AsArray;
        Question[] questionsArray = new Question[questions.Count];
        for( int i = 0; i < questions.Count; i++) {
            questionsArray[i] = new Question(questions[i]);
        }
        Shuffle(questionsArray);
        for(int i = 0; i < questionsArray.Length; i++) {
            _queue.Enqueue(questionsArray[i]);
        }
        Debug.Log("Nº Questions: "+_queue.Count);
    }

    private void Shuffle(Question[] questionsArray) {
        System.Random rng = new System.Random();

        int n = questionsArray.Length;
        while(n > 1) {
            n--;
            int k = rng.Next(n + 1);
            Question value = questionsArray[k];
            questionsArray[k] = questionsArray[n];
            questionsArray[n] = value;
        }
    }

    public static QuestionGenerator Instance
    {
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<QuestionGenerator>();

            return _instance;
        }

        set
        {
            _instance = value;
        }
    }
}
