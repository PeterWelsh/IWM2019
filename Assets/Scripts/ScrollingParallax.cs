using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingParallax : MonoBehaviour
{
    private float length, height, startPosX, startPosY;
    public GameObject cam;
    public GameObject plane;
    public float parallaxEffectX, parallaxEffectY;
    public float camSpeed;
    public float camPosX, camPosY;
    Vector3 camStartPos, planePos;

    private void Awake()
    {
        camStartPos = Camera.main.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void Update()
    {
        planePos = plane.transform.position;

        float temp = (cam.transform.position.x * (1 - parallaxEffectX));
        float dist = (cam.transform.position.x * parallaxEffectX);

        float temp2 = (cam.transform.position.y * (1 - parallaxEffectY));
        float dist2 = (cam.transform.position.y * parallaxEffectY);

        transform.position = new Vector3(startPosX + dist, startPosY + dist2, transform.position.z);

        if (temp > startPosX + length)
        {
            startPosX += length;
        }
        else if (temp < startPosX - length)
        {
            startPosX -= length;
        }
        

        if (temp2 > startPosY + height)
        {
            startPosY += height;
        }
        else if (temp2 < startPosY - height)
        {
            startPosY -= height;
        }

        //camPosX += (camSpeed * Time.deltaTime);
        camPosX = camStartPos.x + planePos.x;
        camPosY = camStartPos.y + planePos.y;

        if (camPosY <  - 4.4f)
        {
            camPosY = -4.4f;
        }

        if (camPosY > 12f)
        {
            camPosY = 12f;
        }

        cam.transform.position = new Vector3(camPosX , camPosY, cam.transform.position.z);

        

        
        //cam.transform.position = new Vector3(startPos + plane.transform.position.x, 0.0f, 0.0f);
        //cam.transform.Translate(new Vector3((7.0f * (parallaxEffect * Time.deltaTime)), 0.0f, 0.0f));
    }
}