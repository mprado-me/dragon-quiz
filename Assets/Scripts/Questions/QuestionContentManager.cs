using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuestionContentManager : MonoBehaviour2 {

    private QuestionBoardController _controller;
    private List<RectTransform> _rectTransforms;
    private float _totalWidth;

	public QuestionContentManager(QuestionBoardController controller) {
        _controller = controller;
        _rectTransforms = new List<RectTransform>();
    }

    public void InitNewQuestionContent() {
        foreach(RectTransform rt in _rectTransforms) {
            Destroy(rt.gameObject);
        }
        _rectTransforms.Clear();
        _totalWidth = 0;
    }

    public void AddText(string text) {
        GameObject textGO = CanvasUtilsFactory.Instance.CreateQuestionAnswerText(text);
        textGO.GetComponent<Text>().SetAlpha(QuestionBoardSettings.Instance.alpha);
        textGO.transform.SetParent(_controller.transform, false);
        textGO.transform.localPosition = Vector3.zero;
        RectTransform rt = textGO.GetComponent<RectTransform>();
        _totalWidth += rt.sizeDelta.x*rt.localScale.x;
        _rectTransforms.Add(rt);
    }

    public void AddImage(string adress) {
        GameObject imageGO = CanvasUtilsFactory.Instance.CreateImage(adress);
        Image img = imageGO.GetComponent<Image>();
        Debug.Log(img);
        img.SetAlpha(QuestionBoardSettings.Instance.alpha);
        imageGO.transform.SetParent(_controller.transform, false);
        imageGO.transform.localPosition = Vector3.zero;
        RectTransform rt = imageGO.GetComponent<RectTransform>();
        _totalWidth += rt.sizeDelta.x * rt.localScale.x;
        _rectTransforms.Add(rt);
    }

    public void FinishNewQuestionContent() {
        _totalWidth += (_rectTransforms.Count-1)*QuestionBoardSettings.Instance.contentDistance;
        float pos = -_totalWidth / 2;
        foreach( RectTransform rt in _rectTransforms) {
            rt.localPosition = new Vector3(pos + rt.sizeDelta.x * rt.localScale.x / 2, rt.localPosition.y);
            pos += rt.sizeDelta.x * rt.localScale.x + QuestionBoardSettings.Instance.contentDistance;
        }
    }
}
