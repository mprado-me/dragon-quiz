﻿using UnityEngine;
using System.Collections;

public class DestroyPipeB : MonoBehaviour2 {

	void Start () {
	
	}
	
	void Update () {
        if(transform.position.x <= PipesSettings.Instance.xToDestroy)
            Destroy(gameObject);
	}
}