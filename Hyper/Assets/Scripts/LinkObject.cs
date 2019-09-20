using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkObject : MonoBehaviour {

    public Transform parent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = parent.position;
	}
}
