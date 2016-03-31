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

        InitVPB initVPB = gameObject.AddComponent<InitVPB>();
        initVPB.SetParams(_up, _down);
        gameObject.AddComponent<MoveXVPB>();
        gameObject.AddComponent<DestroyPB>();
    }
	
	void Update () {
	
	}
}
