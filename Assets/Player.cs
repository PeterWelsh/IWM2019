﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool engine_Failure;
    Rigidbody2D rigidbody2D;
    float time_target = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        engine_Failure = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(-7.0f*Time.deltaTime, 0.0f, 0.0f));

        if(engine_Failure == false)
        {
            if (Input.GetMouseButton(0))
            {
                rigidbody2D.AddForce(new Vector3(0, 50, 0), ForceMode2D.Force);

            }
            else if (Input.GetMouseButtonUp(0))
            {
                rigidbody2D.velocity *= 0.25f;
            }
        }
        else if(engine_Failure == true)
        {
           // rigidbody2D.velocity *= 0.25f;

            time_target -= Time.deltaTime;
            if(time_target <= 0.0f)
            {
                engine_Failure = false;
                time_target = 1.0f;
            }
        }
        
       
    }
}
