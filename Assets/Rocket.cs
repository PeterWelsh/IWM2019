using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Vector3 move;
    public GameObject plane;
    public Animator animator;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
    plane = GameObject.Find("Player");
        player = plane.GetComponent<Player>();
    gameObject.transform.position = new Vector3(plane.transform.position.x - 6, -9.0f, plane.transform.position.z);
       animator = plane.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(gameObject.transform.position, plane.transform.position, 10.0f * Time.deltaTime);
       
        if(gameObject.transform.position == plane.transform.position)
        {
            Debug.Log("Dead");
            animator.SetBool("exploded", true);
            player.dead = true;
            Destroy(gameObject);


        }

    }
}
