﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : MonoBehaviour {

    public float frequency;
    public float amplitude;
    public float theta;
    public float lerpedTheta = 0;
    public int band = 0;

	// Use this for initialization
	void Start () {
        theta = Random.Range(0, 360);
	}
	
	// Update is called once per frame
	void Update () {
        /*
        transform.localRotation = Quaternion.AngleAxis(theta * amplitude, Vector3.right);
        lerpedTheta = Mathf.Lerp(lerpedTheta, theta, Time.deltaTime);
        theta += frequency * Time.deltaTime * Mathf.PI * 2.0f;
        */
        transform.localRotation = Quaternion.AngleAxis(
            Mathf.Sin(theta) * amplitude, Vector3.right);
        theta += frequency * Time.deltaTime * Mathf.PI * 2.0f * AudioAnalyzer.bands[0];
    }
}
