using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atmospher : MonoBehaviour
{
    public GameObject GameObject;
    Player player;
    bool out_off_bounds;
    float timer = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(out_off_bounds == true)
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);
            if(timer <= 0.0f)
            {
                player.engine_Failure = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject)
        {
           
            out_off_bounds = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject)
        {
            out_off_bounds = false;
            timer = 2.0f;
        }
    }

}

