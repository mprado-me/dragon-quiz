using UnityEngine;
using System.Collections;

public class MoveX : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
        transform.position = new Vector3(transform.position.x+Time.deltaTime*ScenariosManager.Instance.vel, transform.position.y);
	}
}