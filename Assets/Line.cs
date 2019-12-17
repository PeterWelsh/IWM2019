using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    float timer = 0.05f;
    Synth synth;
    public Sprite warning;
    SpriteRenderer spriteRenderer;
    public GameObject GameObject;
    public GameObject Warn;
    bool alarm;
    bool on;
    // Start is called before the first frame update
    void Start()
    {
        synth = GameObject.GetComponent<Synth>();
        spriteRenderer = Warn.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(7.0f * Time.deltaTime, 0.0f, 0.0f));

        if (alarm == true)
        {
            timer -= Time.deltaTime;
            if(timer <= 0 && on == true)
            {
                synth.playNote(1831);
                on = false;
                timer = 0.05f;
            }
            else if (timer <= 0 && on == false)
            {
                synth.EndNote();
                on = true;
                timer = 0.05f;
            }
        }
        else if(alarm == false)
        {
            synth.EndNote();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject)
            Warn.SetActive(true);
        spriteRenderer.sprite = warning;
        alarm = true;
        on = true;
        Debug.Log("WARNING");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject)
            Warn.SetActive(false);
        alarm = false;
        on = false;

    }
}
