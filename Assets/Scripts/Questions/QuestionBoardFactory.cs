using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionBoardFactory : MonoBehaviour2 {

    public GameObject questionBoardPrefab;
    public GameObject textPrefab;
    public GameObject imagePrefab;

    private static QuestionBoardFactory _instance;

    public void CreateQuestionBoard() {
        GameObject questionBoard = AddChild(questionBoardPrefab);
        QuestionBoardStorer.Instance.QuestionBoardController = questionBoard.GetComponent<QuestionBoardController>();
    }

    public GameObject CreateText(string text) {
        GameObject textGO = Instantiate(textPrefab);
        Text textComp = textGO.GetComponent<Text>();
        textComp.text = text;
        textComp.rectTransform.sizeDelta = new Vector2(textComp.preferredWidth, textComp.rectTransform.sizeDelta.y);
        return textGO;
    }

    public GameObject CreateImage(string adress) {  
        GameObject imageGO = Instantiate(imagePrefab);
        Image imageComp = imageGO.GetComponent<Image>();
        Sprite sprite = Resources.Load<Sprite>(adress);
        imageComp.sprite = sprite;
        imageComp.rectTransform.sizeDelta = new Vector2(imageComp.rectTransform.sizeDelta.y*sprite.bounds.size.x/ sprite.bounds.size.y, imageComp.rectTransform.sizeDelta.y);
        return imageGO;
    }

    public static QuestionBoardFactory Instance
    {
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<QuestionBoardFactory>();

            return _instance;
        }

        set
        {
            _instance = value;
        }
    }
}
