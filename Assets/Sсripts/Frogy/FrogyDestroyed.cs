using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogyDestroyed : MonoBehaviour
{
    FrogyDancer frogyDancer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.GetComponentInParent< FrogyDancer>().RecountHp(-1);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 6f, ForceMode2D.Impulse);
        }
    }
}
