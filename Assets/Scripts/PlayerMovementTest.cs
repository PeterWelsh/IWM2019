using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovementTest : MonoBehaviour
{
    public float speed = 8.0f;
    float posX = 0;
    public Camera cam;
    Vector3 camPos;

    // Start is called before the first frame update
    void Start()
    {
        //camPos = cam.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        camPos = cam.transform.position;
        posX = camPos.x;

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Moving left");
            posX += speed * Time.deltaTime;
        }

        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }


}