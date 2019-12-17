using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
   public float Player_Score;
    public int click_Number;
    public bool engine_Failure;
    Rigidbody2D rigidbody2D;
    public float max_Y_Vel;
    public float min_Y_Vel;
    //public float time_target = 1.0f;
    public  float Force_Up;
    public float Bonus_boost;
   public GameObject Rocket;
    public bool dead;
    public Animator animator;
    public GameObject panel;


    // Start is called before the first frame update
    void Start()
    {
       // click_Number = 0;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        engine_Failure = false;
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(7.0f*Time.deltaTime, 0.0f, 0.0f));

        if(dead == false)
        {
            if (engine_Failure == false)
            {
                if (Input.GetMouseButton(0))
                {
                    rigidbody2D.AddForce(new Vector3(0, Force_Up, 0), ForceMode2D.Force);
                    animator.SetBool("Up", true);

                }
                else if (Input.GetMouseButtonUp(0))
                {
                    rigidbody2D.velocity *= 0.25f;
                    animator.SetBool("Up", false);
                }

            }
            else if (engine_Failure == true)
            {
                //rigidbody2D.velocity *= 0.5f;
                if (Input.GetMouseButtonDown(0))
                {
                    click_Number++;

                }

                // time_target -= Time.deltaTime;
                if (click_Number >= 5)
                {
                    engine_Failure = false;
                    rigidbody2D.AddForce(new Vector3(0, Force_Up + Bonus_boost, 0), ForceMode2D.Force);
                    click_Number = 0;
                    //time_target = 1.0f;
                }
            }
            if (rigidbody2D.velocity.y > 10.0f)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 10.0f);
              
            }
            if (rigidbody2D.velocity.y < -10.0f)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -10.0f);
                animator.SetBool("Down", true);
            }

        }

        if (dead == true)
        {
            panel.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("CombinedScene");
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene("Ending");
    }
}
