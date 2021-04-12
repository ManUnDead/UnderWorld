﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class GroundPatrol : MonoBehaviour   // Наземный нпс-патрульный
{
    public float speed = 1.5f;
    public bool moveLeft = true;
    public Transform groundDetect;  // Вводим луч-чекер

    // Start is called before the first frame update
    void Start()
    { 
     
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down , 1f );  // 1 наименование в скобках - тот объект от которого идет луч, 2 наименование  - куда идет луч, 3 длина луча.
       if (groundInfo.collider == false)
        {
            if (moveLeft == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                moveLeft = false;
            }

            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveLeft = true;
            }
        } 
    }
}
