using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ColorPlatform : MonoBehaviour
{
    public Color One;
    public Color Two;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<SpriteRenderer>().color = One;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<SpriteRenderer>().color = Two;    

        }
    }
}