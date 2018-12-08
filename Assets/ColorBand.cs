using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBand : MonoBehaviour {
    Renderer r;
    public int band;
	// Use this for initialization
	void Start () {
        r = GetComponent<Renderer>();
	}

    float c = 0;
	// Update is called once per frame
	void Update () {
        c = Mathf.Lerp(c, AudioAnalyzer.bands[band], Time.deltaTime * 10);
        r.material.color = Color.HSVToRGB(
            c 
            , 1, 1);
    }
}
