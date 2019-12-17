using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    // Start is called before the first frame update
    public float jetSpeed, offset = 0.0f;
    Vector3 pos;
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        offset += jetSpeed * Time.deltaTime;
        transform.position = new Vector3(offset, pos.y, pos.z);
    }
}
