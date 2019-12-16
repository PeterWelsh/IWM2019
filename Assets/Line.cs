using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public GameObject GameObject;
    public GameObject Warn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject)
            Warn.SetActive(true);
        Debug.Log("WARNING");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject)
            Warn.SetActive(false);
      
    }
}
