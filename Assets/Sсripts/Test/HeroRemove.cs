using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class HeroRemove : MonoBehaviour
{
    private GameObject player;
    public GameObject hbm;
    int hero = 0;
    bool inPoint = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if (hero == 1)
        {
            player.transform.position = hbm.transform.position;
        }
      
    }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {

            hero =1;

            }
        }

   

    private void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag.Equals("PointToGo"))
        {
            inPoint= true;
            player.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 5000f);
            hero = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("PointToGo"))
        {
            inPoint = false;
        }
    }



}
