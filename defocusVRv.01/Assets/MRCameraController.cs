using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRCameraController : MonoBehaviour {

    private float speed;
    private Vector3[] orientations;
    private int count;

	// Use this for initialization
	void Start () {
        speed = 0;
        orientations = new Vector3[3];
        orientations[0] = new Vector3(180.0f, 180.0f, 180.0f);
        orientations[1] = new Vector3(180.0f, 180.0f, 180.0f);
        orientations[2] = new Vector3(180.0f, 180.0f, 180.0f);
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (count==100)
        {   // Get the average orientation over the last 3ish seconds
            print(transform.position);

            Vector3 avg = Vector3.zero;
            for (int i = 0; i < orientations.Length; i++)
            {
                avg += orientations[i];
            }
            avg /= orientations.Length;

            // If the current orientation is close to the local average, increment speed
            // Else decrement proportionally to how far off it is
            float angle = Vector3.Angle(avg, transform.eulerAngles);
            if (angle < 50) { speed++; }
            else { speed = Math.Max(speed - angle, 0); }

            // Update recent orientations
            orientations[2] = orientations[1];
            orientations[1] = orientations[0];
            orientations[0] = transform.eulerAngles;
            count = 0;
        }
        // Move the camera based on current direction and modified speed
        transform.position += Vector3.ClampMagnitude(transform.eulerAngles, 0.01f) * speed;
        count++;
	}
}


