using UnityEngine;
using System.Collections;
using System;

public class InitFixedVerticalPipeB : MonoBehaviour {

    private Transform _up;
    private Transform _down;

    public void SetParams(Transform up, Transform down) {
        _up = up;
        _down = down;
    }

    void Start () {
        float h = Camera.main.orthographicSize;
        float min = -h + PipesSettings.Instance.yDist / 2 + PipesSettings.Instance.minVisibleYSize;
        float max = h - PipesSettings.Instance.yDist / 2 - PipesSettings.Instance.minVisibleYSize;
        float y = UnityEngine.Random.Range(min, max);
        transform.position = new Vector3(transform.position.x, y);

        BoxCollider2D upColl = _up.GetComponent<BoxCollider2D>();
        BoxCollider2D downColl = _down.GetComponent<BoxCollider2D>();

        _up.localPosition = new Vector3(_up.localPosition.x, (PipesSettings.Instance.yDist + upColl.bounds.size.y) / 2 - upColl.offset.y);
        _down.localPosition = new Vector3(_down.localPosition.x, -(PipesSettings.Instance.yDist + downColl.bounds.size.y) / 2 - downColl.offset.y);
    }
	
	void Update () {
	    
	}
}
