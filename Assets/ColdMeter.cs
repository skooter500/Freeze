using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdMeter : MonoBehaviour {
    public GameObject leftHand;
    public GameObject rightHand;

    private Vector3 lastLeftPos;
    private Vector3 lastRightPos;

    public float leftSpeed;
    public float rightSpeed;

    public float coldness = 1;

    public float thaw = 0.03f;

    // Use this for initialization
    void Start () {
        StartCoroutine(TrackSpeed());
        coldness = 1;
	}

    IEnumerator TrackSpeed()
    {

        yield return new WaitForSeconds(0.5f);

        if (leftHand.activeSelf)
        {
            lastLeftPos = leftHand.transform.position;
        }
        if (rightHand.activeSelf)
        {
            lastRightPos = rightHand.transform.position;
        }
        while (true)
        {
            if (leftHand.activeSelf)
            {
                leftSpeed = Vector3.Distance(leftHand.transform.position, lastLeftPos) / Time.deltaTime;
                if (float.IsNaN(leftSpeed))
                {
                    leftSpeed = 0;
                }
                lastLeftPos = leftHand.transform.position;
            }

            if (rightHand.activeSelf)
            {
                rightSpeed = Vector3.Distance(rightHand.transform.position, lastRightPos) / Time.deltaTime;
                lastRightPos = rightHand.transform.position;
                if (float.IsNaN(rightSpeed))
                {
                    rightSpeed = 0;
                }

            }
            coldness += (leftSpeed + rightSpeed) / 2000;
            yield return null;
        }
    }
    // Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(coldness, coldness, coldness);

        coldness -= thaw * Time.deltaTime;
	}
}
