using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasUtilsFactory : MonoBehaviour2 {

    private static CanvasUtilsFactory _instance;
    public GameObject questionAnswerTextPrefab;
    public GameObject imagePrefab;
    public GameObject additionalTextPrefab;

    public GameObject CreateQuestionAnswerText(string text) {
        GameObject textGO = Instantiate(questionAnswerTextPrefab);
        Text textComp = textGO.GetComponent<Text>();
        textComp.text = text;
        textComp.rectTransform.sizeDelta = new Vector2(textComp.preferredWidth + 1, textComp.rectTransform.sizeDelta.y);
        return textGO;
    }

    public GameObject CreateImage(string adress) {
        GameObject imageGO = Instantiate(imagePrefab);
        Image imageComp = imageGO.GetComponent<Image>();
        Sprite sprite = Resources.Load<Sprite>(adress);
        imageComp.sprite = sprite;
        imageComp.rectTransform.sizeDelta = new Vector2(imageComp.rectTransform.sizeDelta.y * sprite.bounds.size.x / sprite.bounds.size.y, imageComp.rectTransform.sizeDelta.y);
        return imageGO;
    }

    public GameObject CreateAdditionalText(string text) {
        GameObject textGO = Instantiate(additionalTextPrefab);
        textGO.transform.SetParent(transform, false);
        Text textComp = textGO.GetComponent<Text>();
        textComp.text = text;
        return textGO;
    }

    public static CanvasUtilsFactory Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<CanvasUtilsFactory>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
