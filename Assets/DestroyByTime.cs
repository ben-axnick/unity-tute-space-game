using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {
    public float ttl;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, ttl);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
