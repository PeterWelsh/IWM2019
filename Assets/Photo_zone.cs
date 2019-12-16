using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photo_zone : MonoBehaviour
{
    public GameObject Player;
    Player player;
    SpriteRenderer spriteRenderer;
    public GameObject Spy_Cam;
    public float score;
    bool over_zone;

    public enum PhotoState { poor,good,excellent}
    public PhotoState photoState;
    PhotoState pev_photoState;
    // Start is called before the first frame update
    void Start()
    {
        player = Player.GetComponent<Player>();
        photoState = PhotoState.poor;
        pev_photoState = photoState;
        over_zone = false;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(photoState != pev_photoState)
        {
            Debug.Log(photoState);
            pev_photoState = photoState;
        }
        if(Input.GetMouseButtonDown(1))
        {
            if (over_zone == true)
            {
                switch (photoState)
                {
                    case PhotoState.poor:
                        player.Player_Score -= 5;
                        spriteRenderer.color = new Color(1,0,0,0.5f); 
                        break;
                    case PhotoState.good:
                        player.Player_Score += 5;
                        spriteRenderer.color = new Color(1, 0.92f, 0.016f, 0.5f);
                        break;
                    case PhotoState.excellent:
                        player.Player_Score += 10;
                        spriteRenderer.color = new Color(0, 1, 0, 0.5f);
                        break;
                }
                over_zone = false;
            }
           
           
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Player)
        {
            photoState = PhotoState.good;
            over_zone = true;
        }
        if(collision.gameObject == Spy_Cam)
        {
            photoState = PhotoState.excellent;
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            photoState = PhotoState.poor;
        }
        if (collision.gameObject == Spy_Cam)
        {
            photoState = PhotoState.good;
        }
    }
}
