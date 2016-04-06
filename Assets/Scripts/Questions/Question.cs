using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Question {

    public char[] questionType;
    public string[] questionContent;
    public char correctAnswerType;
    public string correctAnswerContent;
    public char incorrectAnswerType;
    public string incorrectAnswerContent;

    public Question(JSONNode json) {
        int n = json[0].AsArray.Count;
        string s;
        questionType = new char[n];
        questionContent = new string[n];
        for( int i = 0; i < n; i++) {
            questionType[i] = json[0][i].ToString()[1];
            s = json[1][i].ToString();
            questionContent[i] = s.Substring(1, s.Length-2);
        }

        correctAnswerType = json[2][0].ToString()[1];
        s = json[2][1].ToString();
        correctAnswerContent = s.Substring(1, s.Length-2);

        incorrectAnswerType = json[3][0].ToString()[1];
        s = json[3][1].ToString();
        incorrectAnswerContent = s.Substring(1, s.Length - 2);
    }
}
