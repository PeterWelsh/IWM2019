using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoOps : MonoBehaviour
{
    public GameObject[] photos;
    Vector3[] photoPos;
    float length, height;
    public Camera cam;
    Vector3 camPos;

    // Start is called before the first frame update
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        camPos = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < photos.Length; i++)
        {
            if(photos[i].transform.position.x < length)
            {
                float randPos = Random.Range(0 - (height / 2), 0 + (height / 2));
                Debug.Log("Random Position Y: " + randPos);
                photoPos[i].y = randPos;
            }
        }
    }
}
