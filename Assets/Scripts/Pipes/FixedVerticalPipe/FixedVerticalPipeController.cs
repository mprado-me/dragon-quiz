using UnityEngine;
using System.Collections;

public class FixedVerticalPipeController : MonoBehaviour2 {

    private Transform _up;
    private Transform _down;

	void Start () {
        foreach( Transform t in GetComponentsInChildren<Transform>()) {
            if(t.ContainTag("Up"))
                _up = t;
            else if(t.ContainTag("Down"))
                _down = t;
        }

        InitFixedVerticalPipeB initFixedVerticalB = gameObject.AddComponent<InitFixedVerticalPipeB>();
        initFixedVerticalB.SetParams(_up, _down);
        gameObject.AddComponent<MoveX>();
        gameObject.AddComponent<DestroyPipeB>();
        gameObject.AddComponent<DestroyOnPlayerEnterInHorizontalPipeB>();
        gameObject.AddComponent<DestroyOnBackToMainMenu>();
    }
	
	void Update () {
	
	}
}
