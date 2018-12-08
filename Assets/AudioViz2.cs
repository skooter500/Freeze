using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioViz2 : MonoBehaviour {
    public float scale = 10;

    public GameObject prefab;

    List<GameObject> elements = new List<GameObject>();
	// Use this for initialization
	void Start () {
        CreateVisualisers();

    }

    public float radius = 50;

    void CreateVisualisers()
    {
        float theta = (Mathf.PI * 2.0f) / (float)AudioAnalyzer.bands.Length;
        for (int i = 0; i < AudioAnalyzer.bands.Length; i++)
        {
            Vector3 p = new Vector3(
                Mathf.Sin(theta * i) * radius
                , 0
                , Mathf.Cos(theta * i) * radius
                );
            p = transform.TransformPoint(p);
            Quaternion q = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg, Vector3.up);
            q = transform.rotation * q;

            GameObject cube;
            //cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube = GameObject.Instantiate<GameObject>(prefab);
            cube.transform.SetPositionAndRotation(p, q);
            cube.transform.parent = this.transform;
            AssignBands(cube, i);

            /*
            cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                i / (float)AudioAnalyzer.bands.Length
                , 1
                , 1
                );
                */
            elements.Add(cube);
        }
    }

    // Update is called once per frame
    void Update () {
        for (int i = 0; i < elements.Count; i++) {
            Vector3 ls = elements[i].transform.localScale;
            float s = Mathf.Lerp(ls.y, 1 + (AudioAnalyzer.bands[i] * scale), Time.deltaTime * 3.0f);
            ls.x = ls.y = ls.z = s;
            //elements[i].transform.localScale = ls;
        }
	}

    void AssignBands(GameObject cube, int band)
    {
        foreach (Dance d in cube.GetComponentsInChildren<Dance>())
        {
            d.band = band;
        }

        foreach (ColorBand b in cube.GetComponentsInChildren<ColorBand>())
        {
            b.band = band;
        }
    }
}
