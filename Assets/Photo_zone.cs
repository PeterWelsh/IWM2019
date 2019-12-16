using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photo_zone : MonoBehaviour
{
    public GameObject Player;
    public GameObject Spy_Cam;

    enum PhotoState { poor,good,excellent}
    PhotoState photoState;
    // Start is called before the first frame update
    void Start()
    {
        photoState = PhotoState.poor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Player)
        {
            photoState = PhotoState.good;
        }
        if(collision.gameObject == Spy_Cam)
        {

        }
    }
}
