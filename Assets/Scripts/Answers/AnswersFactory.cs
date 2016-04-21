using UnityEngine;
using System.Collections;
using System;

public class AnswersFactory : MonoBehaviour2 {

    public GameObject answerPrefab;
    public GameObject smallBaloonPrafab;
    public GameObject mediumBaloonPrafab;

    private float _smallX;
    private float _mediumX;
    private float _upY;
    private float _downY;

    private static AnswersFactory _instance;

    private void initPositions() {
        _smallX = smallBaloonPrafab.transform.localPosition.x;
        _mediumX = mediumBaloonPrafab.transform.localPosition.x;
        _upY = smallBaloonPrafab.transform.localPosition.y;
        _downY = mediumBaloonPrafab.transform.localPosition.y;
    }

    public void CreateUp(AnswerType answerType, string content) {
        GameObject up = Instantiate(answerPrefab);
        up.transform.SetParent(transform, false);
        up.transform.localPosition = new Vector3(up.transform.localPosition.x, _upY);
        CreateAnswer(up, answerType, content);
    }

    public void CreateDown(AnswerType answerType, string content) {
        GameObject down = Instantiate(answerPrefab);
        down.transform.SetParent(transform, false);
        down.transform.localPosition = new Vector3(down.transform.localPosition.x, _downY);
        CreateAnswer(down, answerType, content);
    }

    private void CreateAnswer(GameObject go, AnswerType answerType, string content) {
        GameObject baloon;
        if(answerType == AnswerType.IMAGE) {
            baloon = CreateSmallBaloon();
            baloon.transform.SetParent(go.transform, false);
            baloon.transform.localPosition = Vector3.zero;
            GameObject imageGO = CanvasUtilsFactory.Instance.CreateImage("Images/Icons/"+content);
            imageGO.transform.SetParent(go.transform, false);
            imageGO.transform.localPosition = Vector3.zero;
            go.transform.localPosition = new Vector3(_smallX, go.transform.localPosition.y);
        }
        else { // answerType == AnswerType.TEXT
            GameObject textGO = CanvasUtilsFactory.Instance.CreateQuestionAnswerText(content);
            RectTransform rt = textGO.GetComponent<RectTransform>();
            if(rt.sizeDelta.x <= AnswersSettings.Instance.maxSmallXSize) {
                baloon = CreateSmallBaloon();
                go.transform.localPosition = new Vector3(_smallX, go.transform.localPosition.y);
            }
            else {
                baloon = CreateMediumBaloon();
                go.transform.localPosition = new Vector3(_mediumX, go.transform.localPosition.y);
            }
            baloon.transform.SetParent(go.transform, false);
            baloon.transform.localPosition = Vector3.zero;
            rt.SetParent(go.transform, false);
            rt.localPosition = Vector3.zero;
        }
    }

    private GameObject CreateSmallBaloon() {
        return GameObject.Instantiate(smallBaloonPrafab);
    }

    private GameObject CreateMediumBaloon() {
        return GameObject.Instantiate(mediumBaloonPrafab);
    }

    public static AnswersFactory Instance {
        get {
            if(_instance == null) {
                _instance = GameObject.FindObjectOfType<AnswersFactory>();
                _instance.initPositions();
            }

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}