using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atmospher : MonoBehaviour
{
    public GameObject GameObject;
    public GameObject Warn;
    Player player;
    Synth synth;
    public Sprite warning;
    SpriteRenderer spriteRenderer;
    bool out_off_bounds;
    float timer = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.GetComponent<Player>();
        synth = GameObject.GetComponent<Synth>();
        spriteRenderer = Warn.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(7.0f * Time.deltaTime, 0.0f, 0.0f));

        if (out_off_bounds == true)
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
            Warn.SetActive(true);
            spriteRenderer.sprite = warning;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject)
        {
            out_off_bounds = false;
            Warn.SetActive(false);
            timer = 2.0f;
        }
    }

}

