using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    float c;
    public int band = 2;
	// Update is called once per frame
	void Update () {
        c = Mathf.Lerp(c, AudioAnalyzer.bands[band], Time.deltaTime * 10);
        Camera.main.backgroundColor = Color.HSVToRGB(c, 1, 1);
    }
}
