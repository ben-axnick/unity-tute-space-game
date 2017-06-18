using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {
    public float tumble;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().angularVelocity = tumble * Random.insideUnitSphere;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
