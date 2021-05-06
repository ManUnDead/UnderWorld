using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRepair : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("PlatformDestroy", 1f);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("PlatformRepaire", 3f);
        }
    }

    void PlatformDestroy()
 {
    gameObject.GetComponent<Collider2D>().enabled = false;
 }
    void PlatformRepaire()
    {
     gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
