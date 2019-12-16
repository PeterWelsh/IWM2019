using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int click_Number;
    public bool engine_Failure;
    Rigidbody2D rigidbody2D;
    //public float time_target = 1.0f;
    public  float Force_Up;
    public float Bonus_boost;
    // Start is called before the first frame update
    void Start()
    {
       // click_Number = 0;
        rigidbody2D = GetComponent<Rigidbody2D>();
        engine_Failure = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(-7.0f*Time.deltaTime, 0.0f, 0.0f));

        if (engine_Failure == false)
        {
            if (Input.GetMouseButton(0))
            {
                rigidbody2D.AddForce(new Vector3(0, Force_Up, 0), ForceMode2D.Force);

            }
            else if (Input.GetMouseButtonUp(0))
            {
                rigidbody2D.velocity *= 0.25f;
            }
        }
        else if (engine_Failure == true)
        {
            //rigidbody2D.velocity *= 0.5f;
            if (Input.GetMouseButtonDown(0))
            {
                click_Number++;

            }

            // time_target -= Time.deltaTime;
            if (click_Number >= 5)
            {
                engine_Failure = false;
                rigidbody2D.AddForce(new Vector3(0, Force_Up + Bonus_boost, 0), ForceMode2D.Force);
                click_Number = 0;
                //time_target = 1.0f;
            }
        }


    }
}
