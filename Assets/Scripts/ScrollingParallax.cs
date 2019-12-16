using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingParallax : MonoBehaviour
{
    private float length, startPos;
    public GameObject cam;
    public GameObject plane;
    public float parallaxEffect;
    public float camSpeed;
    float camPosX = 0;
    Vector3 camStartPos, planePos;

    private void Awake()
    {
        camStartPos = Camera.main.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        planePos = plane.transform.position;

        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }

        camPosX += (camSpeed * Time.deltaTime);
        cam.transform.position = new Vector3(camStartPos.x + planePos.x, cam.transform.position.y, cam.transform.position.z);
        //cam.transform.position = new Vector3(startPos + plane.transform.position.x, 0.0f, 0.0f);
        //cam.transform.Translate(new Vector3((7.0f * (parallaxEffect * Time.deltaTime)), 0.0f, 0.0f));
    }
}