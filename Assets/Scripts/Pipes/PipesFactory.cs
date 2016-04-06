using UnityEngine;
using System.Collections;

public class PipesFactory : MonoBehaviour2 {

    public GameObject skyFixedVerticalPipePrefab;

    private static PipesFactory _instance;

    public void CreateFixedVerticalPipe() {
        GameObject pipe = AddChild(skyFixedVerticalPipePrefab);
        pipe.transform.localPosition = Vector3.zero;
    }

    public static PipesFactory Instance
    {
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<PipesFactory>();

            return _instance;
        }

        set
        {
            _instance = value;
        }
    }
}
