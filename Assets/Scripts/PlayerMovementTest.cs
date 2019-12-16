﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{
    public float speed = 5.0f;
    float posX;

    // Start is called before the first frame update
    void Start()
    {
        posX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Moving left");
            posX += speed * Time.deltaTime;
        }

        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
}
