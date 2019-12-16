using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(-7.0f*Time.deltaTime, 0.0f, 0.0f));

        if (Input.GetMouseButton(0))
        {
            rigidbody2D.AddForce(new Vector3(0, 50, 0),ForceMode2D.Force);
           
        }
        else if(Input.GetMouseButtonUp(0))
        {
            rigidbody2D.velocity *= 0.25f;
        }
    }
}
