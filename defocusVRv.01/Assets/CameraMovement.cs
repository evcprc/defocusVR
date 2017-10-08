using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float speed;
    private Vector3[] orientations;
    private int count;
    public GameObject MixedRealityCamera;

    // Use this for initialization
    void Start()
    {
        speed = 0;
        orientations = new Vector3[6];
        orientations[0] = new Vector3(180.0f, 180.0f, 180.0f);
        orientations[1] = new Vector3(180.0f, 180.0f, 180.0f);
        orientations[2] = new Vector3(180.0f, 180.0f, 180.0f);
        orientations[3] = new Vector3(180.0f, 180.0f, 180.0f);
        orientations[4] = new Vector3(180.0f, 180.0f, 180.0f);
        orientations[5] = new Vector3(180.0f, 180.0f, 180.0f);
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (count == 15)
        {   // Get the average orientation over the last 3ish seconds
            Vector3 avg = Vector3.zero;
            for (int i = 0; i < orientations.Length; i++)
            {
                avg += orientations[i];
            }
            avg /= orientations.Length;

            // If the current orientation is close to the local average, increment speed
            // Else decrement proportionally to how far off it is
            float angle = Vector3.Angle(avg, MixedRealityCamera.transform.forward);
            if (angle < 5) { speed ++; }
            else { speed = Math.Max(speed - 1, 0); }

            // Update recent orientations
            orientations[5] = orientations[4];
            orientations[4] = orientations[3];
            orientations[3] = orientations[2];
            orientations[2] = orientations[1];
            orientations[1] = orientations[0];
            orientations[0] = MixedRealityCamera.transform.forward;
            count = 0;
            
            print(avg);
            print(speed);
            print(transform.position);
            print(transform.forward);
            print("");
        }

        // Move the camera based on current direction and modified speed
        transform.position += MixedRealityCamera.transform.forward * speed * Time.deltaTime * 0.01f;
        count++;
    }
}