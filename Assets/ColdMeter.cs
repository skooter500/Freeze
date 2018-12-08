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

    public TextMesh text;

    // Use this for initialization
    void Start () {
        StartCoroutine(TrackSpeed());
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
            coldness += (leftSpeed + rightSpeed) / 3000;
            yield return null;
        }
    }
    // Update is called once per frame
	void Update () {
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            transform.GetChild(i).localScale = new Vector3(coldness, coldness, coldness);
        }

        if (leftSpeed < 0.1f && rightSpeed < 0.1f)
        {
            coldness -= thaw * Time.deltaTime;
        }

        if (coldness <= 0)
        {
            text.text = "The snowman melted! You are are terrible dancer! Press SPACE to Restart";
            FindObjectOfType<AudioSource>().Stop();
            coldness = 0;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                text.text = "Save the Snowpeople! Rave To Summon the cold!";
                FindObjectOfType<AudioSource>().Play();
                coldness = 2;
            }

        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (coldness > 3)
        {
            coldness = 3;
        }
	}
}
