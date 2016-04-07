using UnityEngine;
using System.Collections;

public class HorizontalPipeController : MonoBehaviour2 {

	void Start () {
        gameObject.AddComponent<MoveXHorizontalPipeB>();
        gameObject.AddComponent<DestroyPipeB>();
    }
	
	void Update () {
	
	}
}
