using UnityEngine;
using System.Collections;
using System;

public class AnswersFactory : MonoBehaviour2 {

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

    public void CreateUp(char type, string content) {
        GameObject up = AddChild("UpAnswer");
        up.transform.localPosition = new Vector3(up.transform.localPosition.x, _upY);
        CreateAnswer(up, type, content);
    }

    public void CreateDown(char type, string content) {
        GameObject down = AddChild("DownAnswer");
        down.transform.localPosition = new Vector3(down.transform.localPosition.x, _downY);
        CreateAnswer(down, type, content);
    }

    private void CreateAnswer(GameObject go, char type, string content) {
        GameObject baloon;
        if(type == 'I') {
            baloon = CreateSmallBaloon();
            baloon.transform.SetParent(go.transform, false);
            baloon.transform.localPosition = Vector3.zero;
            GameObject imageGO = CanvasFactory.Instance.CreateImage("Images/Icons/"+content);
            imageGO.transform.SetParent(go.transform, false);
            imageGO.transform.localPosition = Vector3.zero;
            go.transform.localPosition = new Vector3(_smallX, go.transform.localPosition.y);
        }
        else { // type == 'T'
            GameObject textGO = CanvasFactory.Instance.CreateText(content);
            RectTransform rt = textGO.GetComponent<RectTransform>();
            //Debug.Log(rt.sizeDelta.x);
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