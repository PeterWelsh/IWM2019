using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photo_zone : MonoBehaviour
{
    public GameObject Player;
    public GameObject promptSprite;
    SpriteRenderer child_prompt;
    Player player;
    public Sprite Spoor, Sgood, Sexcellent;
    
    SpriteRenderer spriteRenderer;
    public GameObject Spy_Cam;
    public float score;
    bool over_zone;

    public enum PhotoState {Norm, poor,good,excellent}
    public PhotoState photoState;
    PhotoState pev_photoState;
    // Start is called before the first frame update
    void Start()
    {
        child_prompt = promptSprite.GetComponent<SpriteRenderer>();
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
                    case PhotoState.Norm:
                      //child_prompt.sprite = null;


                        break;
                    case PhotoState.poor:
                        player.Player_Score -= 5;
                        child_prompt.sprite = Spoor;
                        promptSprite.SetActive(true);

                        break;
                    case PhotoState.good:
                        player.Player_Score += 5;
                        child_prompt.sprite = Sgood;
                        promptSprite.SetActive(true);

                        break;
                    case PhotoState.excellent:
                        player.Player_Score += 10;
                        child_prompt.sprite = Sexcellent;
                        promptSprite.SetActive(true);
                        break;
                }
                over_zone = false;
            }
           
           
        }

        if (over_zone == true)
        {
            switch (photoState)
            {
                case PhotoState.Norm:
                    spriteRenderer.color = new Color32(0, 249, 255, 255);
                    break;
                case PhotoState.poor:
                    
                    spriteRenderer.color = new Color32(224, 0, 0, 255);
                    break;
                case PhotoState.good:
                    
                    spriteRenderer.color = new Color32(255, 246, 102, 255);
                    break;
                case PhotoState.excellent:
                   
                    spriteRenderer.color = new Color32(0, 244, 64, 255);
                    break;
            }
           // over_zone = false;
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
