using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingParallax : MonoBehaviour
{
    private float length, startPos;
    public GameObject cam;
    public float camSpeed = 2.0f;
    float camPosX = 0;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        camPosX = Camera.main.transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
        
        if(temp > startPos + length)
        {
            startPos += length;
        }
        else if(temp < startPos - length)
        {
            startPos -= length;
        }

        camPosX += camSpeed * Time.deltaTime;
        cam.transform.position = new Vector3(camPosX, cam.transform.position.y, cam.transform.position.z);
    }
}
