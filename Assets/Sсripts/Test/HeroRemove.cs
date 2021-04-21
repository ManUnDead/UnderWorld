using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class HeroRemove : MonoBehaviour
{
    public GameObject player;
    public GameObject hbm;
    int hero = 0;


    void Start()
    {

    }


    void Update()
    {
        if (hero > 0 & hero < 2)
        {
            player.transform.position = hbm.transform.position;
        }

        
    }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {

            hero++;

        }
        }

    private void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag.Equals("PointToGo"))
        {
            hero = 2;
            player.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 5000f);
        }

        else hero = 0;

        
    }
    
}
