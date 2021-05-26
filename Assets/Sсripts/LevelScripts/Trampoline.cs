using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounce;

    private void OnCollisionEnter2D(Collision2D collision) // Если скрипт не работает проверить правильность написания "OnCollisionEnter2D". При не правильном вводе визуал студио не обращает внимания
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * bounce, ForceMode2D.Impulse);
        }
    }
}
