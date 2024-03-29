﻿using UnityEngine;
using System.Collections;

public class PipesFactory : MonoBehaviour2 {

    public GameObject skyFixedVerticalPipePrefab;
    public GameObject greenHorizontalPipePrefab;

    private static PipesFactory _instance;

    public FixedVerticalPipeController CreateFixedVerticalPipe() {
        GameObject pipe = AddChild(skyFixedVerticalPipePrefab);
        pipe.transform.localPosition = Vector3.zero;
        return pipe.GetComponent<FixedVerticalPipeController>();
    }

    public HorizontalPipeController CreateUpHorizontalPipe() {
        GameObject go = CreateHorizontalPipe();
        go.transform.localPosition = new Vector3(go.transform.localPosition.x, PipesSettings.Instance.HorizontalUpY);
        return go.GetComponent<HorizontalPipeController>();
    }

    public HorizontalPipeController CreateDownHorizontalPipe() {
        GameObject go = CreateHorizontalPipe();
        go.transform.localPosition = new Vector3(go.transform.localPosition.x, PipesSettings.Instance.HorizontalDownY);
        return go.GetComponent<HorizontalPipeController>();
    }

    private GameObject CreateHorizontalPipe() {
        GameObject go = AddChild(greenHorizontalPipePrefab);
        go.transform.SetParent(transform, false);
        go.transform.localPosition = Vector3.zero;
        return go;
    }

    public static PipesFactory Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<PipesFactory>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
