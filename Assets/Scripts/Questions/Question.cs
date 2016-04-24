using UnityEngine;
using System.Collections;
using SimpleJSON;

public enum QuestionElementType {
    TEXT,
    IMAGE
}

public enum AnswerType {
    TEXT,
    IMAGE
}

public class Question {

    public QuestionElementType[] questionElementsType;
    public string[] questionContent;
    public AnswerType correctAnswerType;
    public string correctAnswerContent;
    public AnswerType incorrectAnswerType;
    public string incorrectAnswerContent;

    public Question(JSONNode json) {
        int n = json[0].AsArray.Count;
        string s;
        questionElementsType = new QuestionElementType[n];
        questionContent = new string[n];
        for( int i = 0; i < n; i++) {
            if(json[0][i].ToString()[1]=='T')
                questionElementsType[i] = QuestionElementType.TEXT;
            else
                questionElementsType[i] = QuestionElementType.IMAGE;
            s = json[1][i].ToString();
            questionContent[i] = Utils.RemoveBarBefQuote(s.Substring(1, s.Length - 2));
            //questionContent[i] = s.Substring(1, s.Length - 2);
        }

        if(json[2][0].ToString()[1] == 'T')
            correctAnswerType = AnswerType.TEXT;
        else
            correctAnswerType = AnswerType.IMAGE;
        s = json[2][1].ToString();
        correctAnswerContent = s.Substring(1, s.Length-2);

        if(json[3][0].ToString()[1] == 'T')
            incorrectAnswerType = AnswerType.TEXT;
        else
            incorrectAnswerType = AnswerType.IMAGE;
        s = json[3][1].ToString();
        incorrectAnswerContent = s.Substring(1, s.Length - 2);
    }

    public Question(string question, string correctAnswer, string incorrectAnswer) {
        questionElementsType = new QuestionElementType[1];
        questionElementsType[0] = QuestionElementType.TEXT;
        questionContent = new string[1];
        questionContent[0] = question;
        correctAnswerType = AnswerType.TEXT;
        correctAnswerContent = correctAnswer;
        incorrectAnswerType = AnswerType.TEXT;
        incorrectAnswerContent = incorrectAnswer;
    }
}
