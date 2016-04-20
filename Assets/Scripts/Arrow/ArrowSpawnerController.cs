using UnityEngine;
using System.Collections;

public class ArrowSpawnerController : MonoBehaviour2 {

    private float _delta;

	void Start () {
        _delta = 0f;
	}
	
	void Update () {
        _delta += Time.deltaTime;

        if( _delta > ArrowSettings.Instance.spawnerPeriod) {
            _delta = 0f;
            ArrowFactory.Instance.CreateArrow(transform.position, transform.localEulerAngles.z);
        }
	}
}
