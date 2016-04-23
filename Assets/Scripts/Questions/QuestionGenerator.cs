using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class QuestionGenerator : MonoBehaviour2 {

    private static QuestionGenerator _instance;

    private Queue<Question> _queue;

    public void Start() {
        _queue = new Queue<Question>();
        AppendAll();
    }

    public Question GetNew() {
        return _queue.Dequeue();
    }

    private void AppendAll() {
        TextAsset ta = Resources.Load<TextAsset>("questions");
        JSONArray questions = JSON.Parse(ta.text).AsArray;
        for( int i = 0; i < questions.Count; i++) {
            _queue.Enqueue(new Question(questions[i]));
        }
        Debug.Log("Nº Questions: "+_queue.Count);
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
