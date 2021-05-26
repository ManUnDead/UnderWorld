using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Main main;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") //Проверяем тэг объекта. Убедись, что у Игрока есть тег Player
        {
            Invoke("LoadMenu", 0f); //Загружаем сцену
        }
    }

    void LoadMenu()
    {
        main.GetComponent<Main>().MenuLvl();
    }
}
